using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Core.OutputInterfaces;

namespace Org.Ethasia.Adventuregrid.Core.InputInterfaces
{
    public abstract class IslandGenerator
    {
        protected Island result;
        protected int[,] heightMap;
        protected int[,] bottomSpikesHeightMap;
        protected HashSet<BlockPosition> coastlineHeightMap;

        public abstract Island GenerateIsland(int edgeLength, HashSet<BlockPosition> coastlineHeightMap);

        protected void DisplaceHeightMapByLowestPointOfCoastline()
        {
            bottomSpikesHeightMap = new int[result.GetXzDimension(), result.GetXzDimension()];
            int maximumHeightDifference = CalculateMaximumHeightDifference();
            OffsetHeightMapByCoastlineHeightDifference(maximumHeightDifference);          
        }

        protected int CalculateMaximumHeightDifference()
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

        protected void OffsetHeightMapByCoastlineHeightDifference(int maximumHeightDifference)
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

        protected void CreateHeightMapForBottomSpikes()
        {
            IRandomNumberGenerator randomNumberGenerator = CoreFactory.GetInstance().GetRandomNumberGeneratorInstance();
            MathInteractor mathInteractor = InteractorsFactoryForCore.GetInstance().CreateMathInteractorInstance();

            int randomPerlinNoiseOffsetX = randomNumberGenerator.GenerateIntegerBetweenAnd(-100000, 100000);
            int randomPerlinNoiseOffsetY = randomNumberGenerator.GenerateIntegerBetweenAnd(-100000, 100000);

            for (int i = 0; i < result.GetXzDimension(); i++) 
            {
                for (int j = 0; j < result.GetXzDimension(); j++) 
                {
                    float heightValue = ((float)SimplexNoise.Noise((i + randomPerlinNoiseOffsetX) * 0.02f, (j + randomPerlinNoiseOffsetY) * 0.02f) + 1) * 0.4f * Island.HALF_HEIGHT_IN_BLOCKS;
                    int heightValueCeil = mathInteractor.CeilToInt(heightValue);
                    bottomSpikesHeightMap[i, j] = heightValueCeil;
                }
            }
        }

        protected void CreateBlocksBasedOnHeightMap() 
        {
            for (int i = 0; i < heightMap.GetLength(0); i++) 
            {
                for (int j = 0; j < heightMap.GetLength(1); j++) 
                {
                    int blockPillarHeight = heightMap[i, j];
                
                    for (int k = 0; k < blockPillarHeight; k++) 
                    {
                        BlockPosition blockPosition = new BlockPosition(i, k, j);

                        if (k > bottomSpikesHeightMap[i, j])
                        {
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
}