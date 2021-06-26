using static Org.Ethasia.Adventuregrid.Ioadapters.Presenters.StandardIslandPresenter;

using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks 
{
    public class ChunkPresenter
    {
        private readonly List<float[]> floatBuffersOfOpaqueBlocksInChunk;
        private readonly List<int[]> intBuffersOfOpaqueBlocksInChunk;   

        public ChunkPresenter() 
        {
            floatBuffersOfOpaqueBlocksInChunk = new List<float[]>();
            intBuffersOfOpaqueBlocksInChunk = new List<int[]>();             
        }

        public void PresentChunk(Island island, int chunkCoordinateX, int chunkCoordinateY)
        {
            VisualChunkData chunkRenderData = ClearRenderDataForNewChunk();

            FillRenderDataForOneChunk(island, chunkCoordinateX, chunkCoordinateY);

            if (intBuffersOfOpaqueBlocksInChunk.Count > 0) 
            {
                RenderChunk(chunkRenderData, chunkCoordinateX, chunkCoordinateY);
            }
        }

        private VisualChunkData ClearRenderDataForNewChunk()
        {
            floatBuffersOfOpaqueBlocksInChunk.Clear();
            intBuffersOfOpaqueBlocksInChunk.Clear();

            return new VisualChunkData();
        }

        private void FillRenderDataForOneChunk(Island island, int chunkCoordinateX, int chunkCoordinateY) 
        {
            int amountOfBlockVerticesAdded = 0;

            for (int islandX = CHUNK_EDGE_LENGTH_IN_BLOCKS * chunkCoordinateX; islandX < CHUNK_EDGE_LENGTH_IN_BLOCKS * (chunkCoordinateX + 1); islandX++) 
            {
                for (int islandZ = CHUNK_EDGE_LENGTH_IN_BLOCKS * chunkCoordinateY; islandZ < CHUNK_EDGE_LENGTH_IN_BLOCKS * (chunkCoordinateY + 1); islandZ++) 
                {
                    for (int islandY = 0; islandY < Island.HEIGHT_IN_BLOCKS; islandY++) 
                    {
                        if (islandX < island.GetXzDimension() && islandZ < island.GetXzDimension()) 
                        {
                            BlockPosition globalPosition = new BlockPosition(islandX, islandY, islandZ);

                            if (island.GetBlockAt(globalPosition).GetBlockType() != BlockTypes.AIR) 
                            { 
                                int inChunkX = islandX - CHUNK_EDGE_LENGTH_IN_BLOCKS * chunkCoordinateX;
                                int inChunkZ = islandZ - CHUNK_EDGE_LENGTH_IN_BLOCKS * chunkCoordinateY;

                                BlockVisualsBuilder blockVisualsBuilder = BuildBlockVisualsFromBlock(island, globalPosition, inChunkX, inChunkZ, amountOfBlockVerticesAdded);
                            
                                if (blockVisualsBuilder.GetShapePositions().Length > 0) 
                                {   
                                    FillOpaqueBlockBuffersWithVisualRenderData(blockVisualsBuilder);
                                    amountOfBlockVerticesAdded += blockVisualsBuilder.GetNumberOfAddedVertices();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RenderChunk(VisualChunkData chunkToRender, int chunkPositionX, int chunkPositionY)
        {
            ChunkRenderer chunkRenderer = TechnicalsFactory.GetInstance().GetChunkRendererInstance();
            chunkToRender.SetUpWithNumberOfBlocksInChunk(intBuffersOfOpaqueBlocksInChunk.Count);
            chunkToRender.SetWorldPosition(chunkPositionX, chunkPositionY);

            for (int k = 0; k < floatBuffersOfOpaqueBlocksInChunk.Count; k += 3) 
            {
                chunkToRender.AddVerticesToTemporaryBuffer(floatBuffersOfOpaqueBlocksInChunk[k]);
                chunkToRender.AddNormalsToTemporaryBuffer(floatBuffersOfOpaqueBlocksInChunk[k + 1]);
                chunkToRender.AddUvCoordinatesToTemporaryBuffer(floatBuffersOfOpaqueBlocksInChunk[k + 2]);
            }

            for (int k = 0; k < intBuffersOfOpaqueBlocksInChunk.Count; k++) 
            {
                chunkToRender.AddIndicesToTemporaryBuffer(intBuffersOfOpaqueBlocksInChunk[k]);
            }

            chunkToRender.BuildChunkData();
            chunkRenderer.RenderChunk(chunkToRender);
        }

        private BlockVisualsBuilder BuildBlockVisualsFromBlock(Island island, BlockPosition globalPosition, int inChunkX, int inChunkZ, int currentBlockRenderIndex) 
        {
            BlockPosition positionOfBlockInChunk = new BlockPosition(inChunkX, globalPosition.Y, inChunkZ);

            Block currentBlock = island.GetBlockAt(globalPosition);
            BlockVisualsBuilder blockVisualsBuilder = BlockVisualsBuilder.FromBlockType(currentBlock.GetBlockType());
            blockVisualsBuilder.SetBlockToCreateDataFrom(currentBlock)
                .SetPositionOfBlockInChunk(positionOfBlockInChunk)
                .SetIndexBufferOffsetInChunk(currentBlockRenderIndex)
                .SetFrontFaceOfBlockIsHidden(island.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, globalPosition))
                .SetRightFaceOfBlockIsHidden(island.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, globalPosition))
                .SetBackFaceOfBlockIsHidden(island.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, globalPosition))
                .SetLeftFaceOfBlockIsHidden(island.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, globalPosition))
                .SetBottomFaceOfBlockIsHidden(island.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, globalPosition))
                .SetTopFaceOfBlockIsHidden(island.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, globalPosition))
                .Build();  

            return blockVisualsBuilder;
        }

        private void FillOpaqueBlockBuffersWithVisualRenderData(BlockVisualsBuilder blockRenderDataBuilder) 
        {
            floatBuffersOfOpaqueBlocksInChunk.Add(blockRenderDataBuilder.GetShapePositions());
            floatBuffersOfOpaqueBlocksInChunk.Add(blockRenderDataBuilder.GetShapeNormals());
            floatBuffersOfOpaqueBlocksInChunk.Add(blockRenderDataBuilder.GetShapeUvCoordinates());
            intBuffersOfOpaqueBlocksInChunk.Add(blockRenderDataBuilder.GetShapeIndices()); 
        }
    }
}