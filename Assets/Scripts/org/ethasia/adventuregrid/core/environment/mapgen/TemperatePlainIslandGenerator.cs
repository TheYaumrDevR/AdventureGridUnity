using System.Collections.Generic;

using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.InputInterfaces;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class TemperatePlainIslandGenerator : IslandGenerator
    {
        public override Island GenerateIsland(int edgeLength, HashSet<BlockPosition> coastlineHeightMap) 
        {
            result =  new Island(edgeLength);
            this.coastlineHeightMap = coastlineHeightMap;

            PlayerSpawnPointFinder playerSpawnPointFinder = new PlayerSpawnPointFinder();
        
            CreateHeightMap();
            DisplaceHeightMapByLowestPointOfCoastline();
            playerSpawnPointFinder.DeterminePlayerSpawnPoint(result, heightMap);
            CreateHeightMapForBottomSpikes();
            CreateBlocksBasedOnHeightMap();
        
            return result;
        }      

        private void CreateHeightMap() 
        {
            IRandomNumberGenerator randomNumberGenerator = CoreFactory.GetInstance().GetRandomNumberGeneratorInstance();
            heightMap = new int[result.GetXzDimension(), result.GetXzDimension()];

            int randomPerlinNoiseOffsetX = randomNumberGenerator.GenerateIntegerBetweenAnd(-100000, 100000);
            int randomPerlinNoiseOffsetY = randomNumberGenerator.GenerateIntegerBetweenAnd(-100000, 100000);
        
            for (int i = 0; i < result.GetXzDimension(); i++) 
            {
                for (int j = 0; j < result.GetXzDimension(); j++) 
                {
                    BlockPosition coastLineHeightMapDeletedPosition = new BlockPosition(i, -1, j);
                    if (!coastlineHeightMap.Contains(coastLineHeightMapDeletedPosition))
                    {
                        float scaledI = (i + 7023 + randomPerlinNoiseOffsetX) * 4 / 16384.0f;
                        float scaledJ = (j + 4359 + randomPerlinNoiseOffsetY) * 4 / 16384.0f;
                
                        float scaledI2 = (i + 4067 + randomPerlinNoiseOffsetX) * 8 / 8192.0f;
                        float scaledJ2 = (j + 6638 + randomPerlinNoiseOffsetY) * 8 / 8192.0f;
                
                        float scaledI3 = (i + 7650 + randomPerlinNoiseOffsetX) * 16 / 4096.0f;
                        float scaledJ3 = (j + 4014 + randomPerlinNoiseOffsetY) * 16 / 4096.0f;
                
                        float scaledI4 = (i + 7648 + randomPerlinNoiseOffsetX) * 32 / 2048.0f;
                        float scaledJ4 = (j + 3730 + randomPerlinNoiseOffsetY) * 32 / 2048.0f;
                
                        float scaledI5 = (i + 7066 + randomPerlinNoiseOffsetX) * 64 / 1024.0f;
                        float scaledJ5 = (j + 149 + randomPerlinNoiseOffsetY) * 64 / 1024.0f;   

                        float scaledI6 = (i + 1399 + randomPerlinNoiseOffsetX) * 128 / 512.0f;
                        float scaledJ6 = (j + 9036 + randomPerlinNoiseOffsetY) * 128 / 512.0f;                                  
                
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
    }
}