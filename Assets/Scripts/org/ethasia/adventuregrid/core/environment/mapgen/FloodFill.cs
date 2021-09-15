using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{

    public class FloodFill
    {

        private Queue<BlockPosition> outsideIslandFloodFillNodes;
        private HashSet<BlockPosition> coastLineHeightMap;
        private HashSet<BlockPosition> checkedNodes;

        public FloodFill(HashSet<BlockPosition> coastLineHeightMap)
        {
            outsideIslandFloodFillNodes = new Queue<BlockPosition>();
            this.coastLineHeightMap = coastLineHeightMap;
            checkedNodes = new HashSet<BlockPosition>();
        }

        public void MarkBlocksOutsideCoastlineAsEmpty(int coastLineMinHeight, int edgeLengthOfIsland)
        {
            checkedNodes.Clear();

            BlockPosition beginFloodFillNodeTopLeft = new BlockPosition(-1, -1, -1);

            outsideIslandFloodFillNodes.Enqueue(beginFloodFillNodeTopLeft);
            checkedNodes.Add(beginFloodFillNodeTopLeft);

            while (outsideIslandFloodFillNodes.Count > 0)
            {
                BlockPosition firstQueueElement = outsideIslandFloodFillNodes.Dequeue();
                BlockPosition correspondingCoastLineElement = new BlockPosition(firstQueueElement.X, coastLineMinHeight, firstQueueElement.Z);

                if (!coastLineHeightMap.Contains(firstQueueElement) && !coastLineHeightMap.Contains(correspondingCoastLineElement))
                {
                    if (firstQueueElement.X > -1 && firstQueueElement.X < edgeLengthOfIsland && firstQueueElement.Z > -1 && firstQueueElement.Z < edgeLengthOfIsland)
                    {
                        coastLineHeightMap.Add(firstQueueElement);
                    }                    

                    if (firstQueueElement.X > -1)
                    {
                        BlockPosition westernNode = new BlockPosition(firstQueueElement.X - 1, -1, firstQueueElement.Z);
                        EnqueueAndAddNodeIfItDoesNotExist(westernNode);
                    }

                    if (firstQueueElement.X < edgeLengthOfIsland)
                    {
                        BlockPosition easternNode = new BlockPosition(firstQueueElement.X + 1, -1, firstQueueElement.Z);
                        EnqueueAndAddNodeIfItDoesNotExist(easternNode);
                    }  

                    if (firstQueueElement.Z > -1)
                    {
                        BlockPosition northernNode = new BlockPosition(firstQueueElement.X, -1, firstQueueElement.Z - 1);
                        EnqueueAndAddNodeIfItDoesNotExist(northernNode);
                    }      

                    if (firstQueueElement.Z < edgeLengthOfIsland)
                    {
                        BlockPosition southernNode = new BlockPosition(firstQueueElement.X, -1, firstQueueElement.Z + 1);
                        EnqueueAndAddNodeIfItDoesNotExist(southernNode);
                    }                                                        
                }
            }            
        }

        private void EnqueueAndAddNodeIfItDoesNotExist(BlockPosition node)
        {
            if (!checkedNodes.Contains(node))
            {
                outsideIslandFloodFillNodes.Enqueue(node);
                checkedNodes.Add(node);
            }
        }
    }
}