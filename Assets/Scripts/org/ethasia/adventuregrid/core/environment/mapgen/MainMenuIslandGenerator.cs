using System.Collections.Generic;

using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;
using Org.Ethasia.Adventuregrid.Core.InputInterfaces;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class MainMenuIslandGenerator : IslandGenerator
    {
        public override Island GenerateIsland(int edgeLength, HashSet<BlockPosition> coastlineHeightMap) 
        {
            result =  new Island(edgeLength);
            this.coastlineHeightMap = coastlineHeightMap;
        
            CreateHeightMap();
            SetFixedIslandHeight();
            DisplaceHeightMapByLowestPointOfCoastline();
            CreateBlocksBasedOnHeightMap();
            PaveGravelRoad();
            PlaceSigns();
        
            return result;
        }

        private void SetFixedIslandHeight()
        {
            int fixedIslandHeight = 8;
            HashSet<BlockPosition> newCoastlineHeightMap = new HashSet<BlockPosition>();

            foreach (BlockPosition coastLinePoint in coastlineHeightMap)
            {
                newCoastlineHeightMap.Add(new BlockPosition(coastLinePoint.X, fixedIslandHeight, coastLinePoint.Z));
            }    

            coastlineHeightMap = newCoastlineHeightMap;
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
                        float islandHeightNoise = ((float)SimplexNoise.Noise(i * 0.0001f, j * 0.0001f) + 1) * 0.1f * Island.HALF_HEIGHT_IN_BLOCKS;
                        heightMap[i, j] = Mathf.CeilToInt(islandHeightNoise);             
                    }
                }            
            }
        }  

        private void PaveGravelRoad()
        {
            Block gravelBlock = GravelBlock.GetInstance();

            for (int i = 16; i < 60; i++)
            {
                result.PlaceBlockAt(gravelBlock, new BlockPosition(i, 20, 20));
                result.PlaceBlockAt(gravelBlock, new BlockPosition(i, 20, 19));

                if (i > 16)
                {
                    result.PlaceBlockAt(gravelBlock, new BlockPosition(i, 20, 18));
                }
            }

            for (int j = 0; j < 18; j++)
            {
                if (j > 1)
                {
                    result.PlaceBlockAt(gravelBlock, new BlockPosition(49, 20, j));
                }

                if (j > 0)
                {
                    result.PlaceBlockAt(gravelBlock, new BlockPosition(48, 20, j));
                }
                
                result.PlaceBlockAt(gravelBlock, new BlockPosition(47, 20, j));
            }
        } 

        private void PlaceSigns()
        {
            Block walnutPoleBlock = WalnutPoleBlock.GetInstance();
            result.PlaceBlockAt(walnutPoleBlock, new BlockPosition(46, 21, 17));
            result.PlaceBlockAt(walnutPoleBlock, new BlockPosition(46, 22, 17));
            result.PlaceBlockAt(walnutPoleBlock, new BlockPosition(46, 23, 17));

            Block quitGameSignPlateBlock = WalnutWoodArrowSignplateBlock.GetInstance();
            result.PlaceBlockAt(quitGameSignPlateBlock, new BlockPosition(47, 24, 17));

            Block newGameSignPlateBlock = WalnutWoodArrowSignplateBlock.GetInstance();

            RotationVisitor blockRotator = RotationVisitor.GetInstance();
            newGameSignPlateBlock.Visit(blockRotator);

            blockRotator.RotatePositiveAroundYAxis();
            blockRotator.RotatePositiveAroundYAxis();

            result.PlaceBlockAt(newGameSignPlateBlock, new BlockPosition(45, 24, 17));            
        }        
    }
}