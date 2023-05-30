using static Org.Ethasia.Adventuregrid.Ioadapters.Presenters.StandardIslandPresenter;

using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks 
{
    public class ChunkPresenter
    {
        private static readonly HashSet<BlockTypes> FOLIAGE_BLOCK_TYPES;

        private readonly List<float[]> floatBuffersOfOpaqueBlocksInChunk;
        private readonly List<int[]> intBuffersOfOpaqueBlocksInChunk;   

        private readonly List<float[]> floatBuffersOfFoliageBlocksInChunk;
        private readonly List<int[]> intBuffersOfFoliageBlocksInChunk;

        static ChunkPresenter()
        {
            FOLIAGE_BLOCK_TYPES = new HashSet<BlockTypes>();
            FOLIAGE_BLOCK_TYPES.Add(BlockTypes.CHICKWEED_CROP);
        }

        public ChunkPresenter() 
        {
            floatBuffersOfOpaqueBlocksInChunk = new List<float[]>();
            intBuffersOfOpaqueBlocksInChunk = new List<int[]>();  

            floatBuffersOfFoliageBlocksInChunk = new List<float[]>();
            intBuffersOfFoliageBlocksInChunk = new List<int[]>();                        
        }

        public void PresentChunk(Island island, int chunkCoordinateX, int chunkCoordinateY)
        {
            ClearRenderDataForNewChunk();

            VisualChunkData opaqueChunkRenderData = new VisualChunkData();
            VisualChunkData foliageChunkRenderData = new VisualChunkData();

            opaqueChunkRenderData.ChunkType = ChunkTypes.STANDARD;
            foliageChunkRenderData.ChunkType = ChunkTypes.FOLIAGE;

            FillRenderDataForOneChunk(island, chunkCoordinateX, chunkCoordinateY);

            if (intBuffersOfOpaqueBlocksInChunk.Count > 0) 
            {
                RenderOpaqueChunk(opaqueChunkRenderData, chunkCoordinateX, chunkCoordinateY);
            }

            if (intBuffersOfFoliageBlocksInChunk.Count > 0) 
            {
                RenderFoliageChunk(foliageChunkRenderData, chunkCoordinateX, chunkCoordinateY);
            }            
        }

        private void ClearRenderDataForNewChunk()
        {
            floatBuffersOfOpaqueBlocksInChunk.Clear();
            intBuffersOfOpaqueBlocksInChunk.Clear();

            floatBuffersOfFoliageBlocksInChunk.Clear();
            intBuffersOfFoliageBlocksInChunk.Clear();            
        }

        private void FillRenderDataForOneChunk(Island island, int chunkCoordinateX, int chunkCoordinateY) 
        {
            int amountOfOpaqueBlockVerticesAdded = 0;
            int amountOfFoliageBlockVerticesAdded = 0;

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

                                BlockVisualsBuilder blockVisualsBuilder;
                                if (FOLIAGE_BLOCK_TYPES.Contains(island.GetBlockAt(globalPosition).GetBlockType()))
                                {
                                    blockVisualsBuilder = BuildBlockVisualsFromBlock(island, globalPosition, inChunkX, inChunkZ, amountOfFoliageBlockVerticesAdded);
                                }
                                else
                                {
                                    blockVisualsBuilder = BuildBlockVisualsFromBlock(island, globalPosition, inChunkX, inChunkZ, amountOfOpaqueBlockVerticesAdded);
                                }
                            
                                if (blockVisualsBuilder.GetShapePositions().Length > 0) 
                                {   
                                    if (FOLIAGE_BLOCK_TYPES.Contains(island.GetBlockAt(globalPosition).GetBlockType()))
                                    {
                                        FillFoliageBlockBuffersWithVisualRenderData(blockVisualsBuilder);
                                        amountOfFoliageBlockVerticesAdded += blockVisualsBuilder.GetNumberOfAddedVertices();
                                    }
                                    else
                                    {
                                        FillOpaqueBlockBuffersWithVisualRenderData(blockVisualsBuilder);
                                        amountOfOpaqueBlockVerticesAdded += blockVisualsBuilder.GetNumberOfAddedVertices();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RenderOpaqueChunk(VisualChunkData chunkToRender, int chunkPositionX, int chunkPositionY)
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

        private void RenderFoliageChunk(VisualChunkData chunkToRender, int chunkPositionX, int chunkPositionY)
        {
            ChunkRenderer chunkRenderer = TechnicalsFactory.GetInstance().GetChunkRendererInstance();
            chunkToRender.SetUpWithNumberOfBlocksInChunk(intBuffersOfFoliageBlocksInChunk.Count);
            chunkToRender.SetWorldPosition(chunkPositionX, chunkPositionY);

            for (int k = 0; k < floatBuffersOfFoliageBlocksInChunk.Count; k += 3) 
            {
                chunkToRender.AddVerticesToTemporaryBuffer(floatBuffersOfFoliageBlocksInChunk[k]);
                chunkToRender.AddNormalsToTemporaryBuffer(floatBuffersOfFoliageBlocksInChunk[k + 1]);
                chunkToRender.AddUvCoordinatesToTemporaryBuffer(floatBuffersOfFoliageBlocksInChunk[k + 2]);
            }

            for (int k = 0; k < intBuffersOfFoliageBlocksInChunk.Count; k++) 
            {
                chunkToRender.AddIndicesToTemporaryBuffer(intBuffersOfFoliageBlocksInChunk[k]);
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
                .SetBlockRotationState(ExtractRotationState(currentBlock))
                .SetBlockAttachmentState(ExtractAttachmentState(currentBlock))
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

        private void FillFoliageBlockBuffersWithVisualRenderData(BlockVisualsBuilder blockRenderDataBuilder)
        {
            floatBuffersOfFoliageBlocksInChunk.Add(blockRenderDataBuilder.GetShapePositions());
            floatBuffersOfFoliageBlocksInChunk.Add(blockRenderDataBuilder.GetShapeNormals());
            floatBuffersOfFoliageBlocksInChunk.Add(blockRenderDataBuilder.GetShapeUvCoordinates());
            intBuffersOfFoliageBlocksInChunk.Add(blockRenderDataBuilder.GetShapeIndices()); 
        }

        private RotationStates ExtractRotationState(Block currentBlock)
        {
            RotationDataExtractionVisitor rotationStateExtractor = RotationDataExtractionVisitor.GetInstance();
            currentBlock.Visit(rotationStateExtractor);

            if (rotationStateExtractor.HasRotationState)
            {
                return rotationStateExtractor.ExtractedRotationState.GetRotationIdentifier();
            }

            return RotationStates.FRONT_POINTING_UP;
        } 

        private BlockAttachmentState ExtractAttachmentState(Block currentBlock)
        {
            BlockAttachmentState result = new BlockAttachmentState();

            BlockNeighborAttachmentInfoVisitor attachmentStateExtractor = BlockNeighborAttachmentInfoVisitor.GetInstance();
            currentBlock.Visit(attachmentStateExtractor);

            result.IsAttachedToLeftNeighbor = attachmentStateExtractor.IsAttachedToLeftBlock();
            result.IsAttachedToFrontNeighbor = attachmentStateExtractor.IsAttachedToFrontBlock();
            result.IsAttachedToRightNeighbor = attachmentStateExtractor.IsAttachedToRightBlock();
            result.IsAttachedToBackNeighbor = attachmentStateExtractor.IsAttachedToBackBlock();
            result.IsAttachedToTopNeighbor = attachmentStateExtractor.IsAttachedToTopBlock();
            result.IsAttachedToBottomNeighbor = attachmentStateExtractor.IsAttachedToBottomBlock();

            return result;
        }
    }
}