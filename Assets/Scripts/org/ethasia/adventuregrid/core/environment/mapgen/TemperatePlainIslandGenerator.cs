using UnityEngine;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class TemperatePlainIslandGenerator
    {

        private Island result;
        private int[,] heightMap;

        public Island GenerateIsland(int edgeLength) 
        {
            result =  new Island(edgeLength);
        
            CreateHeightMap();
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
                    float scaledI = (i + 2000) * 4 / 128.0f;
                    float scaledJ = (j + 2000) * 4 / 128.0f;
                
                    float scaledI2 = (i + 2000) * 8 / 128.0f;
                    float scaledJ2 = (j + 2000) * 8 / 128.0f;
                
                    float scaledI3 = (i + 2000) * 16 / 128.0f;
                    float scaledJ3 = (j + 2000) * 16 / 128.0f;
                
                    float scaledI4 = (i + 2000) * 32 / 128.0f;
                    float scaledJ4 = (j + 2000) * 32 / 128.0f;
                
                    float scaledI5 = (i + 2000) * 64 / 128.0f;
                    float scaledJ5 = (j + 2000) * 64 / 128.0f;                
                
                    float normalizedNoise = (float)((SimplexNoise.Noise(scaledI, scaledJ) + 1) * 0.5f);
                    float normalizedNoise2 = (float)((SimplexNoise.Noise(scaledI2, scaledJ2) + 1) * 0.25f);
                    float normalizedNoise3 = (float)((SimplexNoise.Noise(scaledI3, scaledJ3) + 1) * 0.125f);
                    float normalizedNoise4 = (float)((SimplexNoise.Noise(scaledI4, scaledJ4) + 1) * 0.0625f);
                    float normalizedNoise5 = (float)((SimplexNoise.Noise(scaledI5, scaledJ5) + 1) * 0.03125f);
                
                    float finalNoise = (normalizedNoise + normalizedNoise2 + normalizedNoise3 + normalizedNoise4 + normalizedNoise5) / 5.0f;
                    float redistirbutedNoise = Mathf.Pow(finalNoise, 1.4f);
                
                    heightMap[i, j] = Mathf.CeilToInt(redistirbutedNoise * Island.HEIGHT_IN_BLOCKS);
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