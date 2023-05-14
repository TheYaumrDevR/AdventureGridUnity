using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{
    public class PlayerSpawnPointFinder
    {
        private Island spawnIsland;
        private int[,] islandHeightMap;

        public void DeterminePlayerSpawnPoint(Island spawnIsland, int[,] islandHeightMap)
        {
            this.spawnIsland = spawnIsland;
            this.islandHeightMap = islandHeightMap;            

            int islandEdgeLength = spawnIsland.GetXzDimension();
            int islandHalfPoint = (islandEdgeLength / 2) - 1;

            if (0 < islandHeightMap[islandHalfPoint, islandHalfPoint])
            {
                spawnIsland.PlayerSpawnPosition = new BlockPosition(islandHalfPoint, islandHeightMap[islandHalfPoint, islandHalfPoint], islandHalfPoint);
            }
            else
            {
                DeterminePlayerSpawnPointRecursive(1);
            }
        }      

        private void DeterminePlayerSpawnPointRecursive(int recursionDepth)
        {
            int islandEdgeLength = spawnIsland.GetXzDimension();
            int islandHalfPoint = (islandEdgeLength / 2) - 1;

            int iterationOffsetPositive = islandHalfPoint + recursionDepth;
            int iterationOffsetNegative = islandHalfPoint - recursionDepth;

            if (iterationOffsetPositive >= islandEdgeLength && iterationOffsetNegative < 0)
            {
                return;
            }  

            if (LookForSpawnPointOnLeftSide(iterationOffsetPositive, iterationOffsetNegative))
            {
                return;
            }

            if (LookForSpawnPointOnTopSide(iterationOffsetPositive, iterationOffsetNegative))
            {
                return;
            }   

            if (LookForSpawnPointOnRightSide(iterationOffsetPositive, iterationOffsetNegative))
            {
                return;
            }    

            if (LookForSpawnPointOnBottomSide(iterationOffsetPositive, iterationOffsetNegative))
            {
                return;
            }                                 

            DeterminePlayerSpawnPointRecursive(recursionDepth + 1);                               
        }     

        private bool LookForSpawnPointOnLeftSide(int iterationOffsetPositive, int iterationOffsetNegative)
        {
            int islandEdgeLength = spawnIsland.GetXzDimension();

            for (int j = iterationOffsetPositive; j >= iterationOffsetNegative; j--)
            {
                if (iterationOffsetPositive < islandEdgeLength && j >= 0)
                {
                    if (0 < islandHeightMap[iterationOffsetPositive, j])
                    {
                        spawnIsland.PlayerSpawnPosition = new BlockPosition(iterationOffsetPositive, islandHeightMap[iterationOffsetPositive, j], j);
                        return true;
                    } 
                }
            }

            return false;
        }   

        private bool LookForSpawnPointOnTopSide(int iterationOffsetPositive, int iterationOffsetNegative)
        {
            int islandEdgeLength = spawnIsland.GetXzDimension();

            for (int i = iterationOffsetPositive; i >= iterationOffsetNegative; i--)
            {
                if (iterationOffsetNegative >= 0 && i < islandEdgeLength && i >= 0)
                {
                    if (0 < islandHeightMap[i, iterationOffsetNegative])
                    {
                        spawnIsland.PlayerSpawnPosition = new BlockPosition(i, islandHeightMap[i, iterationOffsetNegative], iterationOffsetNegative);
                        return true;
                    } 
                }
            }

            return false;
        } 

        private bool LookForSpawnPointOnRightSide(int iterationOffsetPositive, int iterationOffsetNegative)
        {
            int islandEdgeLength = spawnIsland.GetXzDimension();

            for (int j = iterationOffsetNegative; j <= iterationOffsetPositive; j++)
            {
                if (iterationOffsetNegative >= 0 && j < islandEdgeLength)
                {
                    if (0 < islandHeightMap[iterationOffsetNegative, j])
                    {
                        spawnIsland.PlayerSpawnPosition = new BlockPosition(iterationOffsetNegative, islandHeightMap[iterationOffsetNegative, j], j);
                        return true;
                    } 
                }
            } 

            return false;
        }  

        private bool LookForSpawnPointOnBottomSide(int iterationOffsetPositive, int iterationOffsetNegative)
        {
            int islandEdgeLength = spawnIsland.GetXzDimension();

            for (int i = iterationOffsetNegative; i <= iterationOffsetPositive; i++)
            {
                if (iterationOffsetPositive < islandEdgeLength && i >= 0 && i < islandEdgeLength)
                {
                    if (0 < islandHeightMap[i, iterationOffsetPositive])
                    {
                        spawnIsland.PlayerSpawnPosition = new BlockPosition(i, islandHeightMap[i, iterationOffsetPositive], iterationOffsetPositive);
                        return true;
                    } 
                }
            }  

            return false;
        } 
    }
}