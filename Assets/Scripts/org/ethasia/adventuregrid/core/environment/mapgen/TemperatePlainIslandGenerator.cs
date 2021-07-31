using System.Collections.Generic;

using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.InputInterfaces;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class TemperatePlainIslandGenerator : IslandGenerator
    {

        private Island result;
        private int[,] heightMap;
        private HashSet<BlockPosition> coastlineHeightMap;

        public Island GenerateIsland(int edgeLength, HashSet<BlockPosition> coastlineHeightMap) 
        {
            result =  new Island(edgeLength);
            this.coastlineHeightMap = coastlineHeightMap;
        
            CreateHeightMap();
            DisplaceHeightMapByLowestPointOfCoastline();
            CreateBlocksBasedOnHeightMap();
        
            return result;
        }      

        private void CreateHeightMap() 
        {
            heightMap = new int[result.GetXzDimension(), result.GetXzDimension()];
        
            for (int i = 0; i < result.GetXzDimension(); i++) 
            {
                for (int j = 0; j < result.GetXzDimension(); j++) 
                {
                    BlockPosition coastLineHeightMapDeletedPosition = new BlockPosition(i, -1, j);
                    if (!coastlineHeightMap.Contains(coastLineHeightMapDeletedPosition))
                    {
                        float scaledI = (i + 7023) * 4 / 16384.0f;
                        float scaledJ = (j + 4359) * 4 / 16384.0f;
                
                        float scaledI2 = (i + 4067) * 8 / 8192.0f;
                        float scaledJ2 = (j + 6638) * 8 / 8192.0f;
                
                        float scaledI3 = (i + 7650) * 16 / 4096.0f;
                        float scaledJ3 = (j + 4014) * 16 / 4096.0f;
                
                        float scaledI4 = (i + 7648) * 32 / 2048.0f;
                        float scaledJ4 = (j + 3730) * 32 / 2048.0f;
                
                        float scaledI5 = (i + 7066) * 64 / 1024.0f;
                        float scaledJ5 = (j + 149) * 64 / 1024.0f;   

                        float scaledI6 = (i + 1399) * 128 / 512.0f;
                        float scaledJ6 = (j + 9036) * 128 / 512.0f;                                  
                
                        float normalizedNoise = (float)((SimplexNoise.Noise(scaledI, scaledJ) + 1) * 0.5f);
                        float normalizedNoise2 = (float)((SimplexNoise.Noise(scaledI2, scaledJ2) + 1) * 0.25f);
                        float normalizedNoise3 = (float)((SimplexNoise.Noise(scaledI3, scaledJ3) + 1) * 0.125f);
                        float normalizedNoise4 = (float)((SimplexNoise.Noise(scaledI4, scaledJ4) + 1) * 0.0625f);
                        float normalizedNoise5 = (float)((SimplexNoise.Noise(scaledI5, scaledJ5) + 1) * 0.03125f);
                        float normalizedNoise6 = (float)((SimplexNoise.Noise(scaledI6, scaledJ6) + 1) * 0.015625f);
                
                        float finalNoise = (normalizedNoise + normalizedNoise2 + normalizedNoise3 + normalizedNoise4 + normalizedNoise5 + normalizedNoise6) / 6.0f;
                        float redistirbutedNoise = Mathf.Pow(finalNoise, 2.0f);
                
                        heightMap[i, j] = Mathf.CeilToInt(redistirbutedNoise * Island.HEIGHT_IN_BLOCKS);                        
                    }
                }            
            }
        }

        private void DisplaceHeightMapByLowestPointOfCoastline()
        {
            int maximumHeightDifference = CalculateMaximumHeightDifference();
            OffsetHeightMapByCoastlineHeightDifference(maximumHeightDifference);           
        }

        private int CalculateMaximumHeightDifference()
        {
            int result = -255;
            foreach (BlockPosition coastLinePoint in coastlineHeightMap)
            {
                if (coastLinePoint.Y > -1)
                {
                    int correspondingTerrainPointHeight = heightMap[coastLinePoint.X, coastLinePoint.Z];
                    int heightDifference = coastLinePoint.Y - correspondingTerrainPointHeight;

                    if (heightDifference > result)
                    {
                        result = heightDifference;
                    }
                }
            }    

            return result;        
        }

        private void OffsetHeightMapByCoastlineHeightDifference(int maximumHeightDifference)
        {
            for (int i = 0; i < result.GetXzDimension(); i++) 
            {
                for (int j = 0; j < result.GetXzDimension(); j++) 
                {
                    int newHeight = heightMap[i, j] + maximumHeightDifference;

                    if (heightMap[i, j] > 0)
                    {
                        if (newHeight > 255)
                        {
                            newHeight = 255;
                        } 
                        else if (newHeight < 0)
                        {
                            newHeight = 0;
                        }

                        heightMap[i, j] = newHeight;
                    }
                }
            } 
        }

        private void CreateBlocksBasedOnHeightMap() 
        {
            for (int i = 0; i < heightMap.GetLength(0); i++) 
            {
                for (int j = 0; j < heightMap.GetLength(1); j++) 
                {
                    int blockPillarHeight = heightMap[i, j];
                
                    for (int k = 0; k < blockPillarHeight; k++) 
                    {
                        BlockPosition blockPosition = new BlockPosition(i, k, j);

                        if (k < blockPillarHeight - 2) 
                        {
                            result.PlaceBlockAt(RockBlock.GetInstance(), blockPosition);
                        } 
                        else if (k < blockPillarHeight - 1) 
                        {
                            result.PlaceBlockAt(EarthBlock.GetInstance(), blockPosition);
                        } 
                        else 
                        {
                            result.PlaceBlockAt(GrassyEarthBlock.GetInstance(), blockPosition);
                        }
                    }
                }
            }
        }                   
    }
}