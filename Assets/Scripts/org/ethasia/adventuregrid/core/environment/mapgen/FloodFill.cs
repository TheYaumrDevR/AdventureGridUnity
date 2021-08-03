using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{

    public class FloodFill
    {

        private Queue<BlockPosition> outsideIslandFloodFillNodes;
        private HashSet<BlockPosition> coastLineHeightMap;

        public FloodFill(HashSet<BlockPosition> coastLineHeightMap)
        {
            outsideIslandFloodFillNodes = new Queue<BlockPosition>();
            this.coastLineHeightMap = coastLineHeightMap;
        }

        public void MarkBlocksOutsideCoastlineAsEmpty(int coastLineMinHeight, int edgeLengthOfIsland)
        {
            HashSet<BlockPosition> checkedNodes = new HashSet<BlockPosition>();

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

                        if (!checkedNodes.Contains(westernNode))
                        {
                            outsideIslandFloodFillNodes.Enqueue(westernNode);
                            checkedNodes.Add(westernNode);
                        }
                    }

                    if (firstQueueElement.X < edgeLengthOfIsland)
                    {
                        BlockPosition easternNode = new BlockPosition(firstQueueElement.X + 1, -1, firstQueueElement.Z);

                        if (!checkedNodes.Contains(easternNode))
                        {
                            outsideIslandFloodFillNodes.Enqueue(easternNode);
                            checkedNodes.Add(easternNode);
                        }
                    }  

                    if (firstQueueElement.Z > -1)
                    {
                        BlockPosition northernNode = new BlockPosition(firstQueueElement.X, -1, firstQueueElement.Z - 1);

                        if (!checkedNodes.Contains(northernNode))
                        {
                            outsideIslandFloodFillNodes.Enqueue(northernNode);
                            checkedNodes.Add(northernNode);
                        }
                    }      

                    if (firstQueueElement.Z < edgeLengthOfIsland)
                    {
                        BlockPosition southernNode = new BlockPosition(firstQueueElement.X, -1, firstQueueElement.Z + 1);

                        if (!checkedNodes.Contains(southernNode))
                        {
                            outsideIslandFloodFillNodes.Enqueue(southernNode);
                            checkedNodes.Add(southernNode);
                        }
                    }                                                        
                }
            }            
        }
    }
}