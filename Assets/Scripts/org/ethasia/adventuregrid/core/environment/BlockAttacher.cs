using System;

using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    class BlockAttacher
    {
        private Island island;

        public BlockAttacher(Island island)
        {
            this.island = island;
        }

        public void AttachEligibleBlocksToNeighborBlock(BlockPosition position)
        {
            Block middleBlock = island.GetBlockAt(position);

            AttachEligibleLeftNeighborBlock(position, middleBlock);
            AttachEligibleRightNeighborBlock(position, middleBlock);
            AttachEligibleFrontNeighborBlock(position, middleBlock);
            AttachEligibleBackNeighborBlock(position, middleBlock);
            AttachEligibleTopNeighborBlock(position, middleBlock);
            AttachEligibleBottomNeighborBlock(position, middleBlock);
        }

        private void AttachEligibleLeftNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X + 1, position.Y, position.Z);
            AttachEligibleNeighborBlock(neighborPosition, middleBlock, neighborBlockAttachingVisitor.BlockWasPlacedToLeft, neighborBlockAttachingVisitor.BlockWasPlacedToRight);           
        }

        private void AttachEligibleRightNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X - 1, position.Y, position.Z);
            AttachEligibleNeighborBlock(neighborPosition, middleBlock, neighborBlockAttachingVisitor.BlockWasPlacedToRight, neighborBlockAttachingVisitor.BlockWasPlacedToLeft);               
        }

        private void AttachEligibleFrontNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y, position.Z + 1);
            AttachEligibleNeighborBlock(neighborPosition, middleBlock, neighborBlockAttachingVisitor.BlockWasPlacedToFront, neighborBlockAttachingVisitor.BlockWasPlacedToBack);       
        }

        private void AttachEligibleBackNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y, position.Z - 1);
            AttachEligibleNeighborBlock(neighborPosition, middleBlock, neighborBlockAttachingVisitor.BlockWasPlacedToBack, neighborBlockAttachingVisitor.BlockWasPlacedToFront);    
        }    

        private void AttachEligibleTopNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y + 1, position.Z);
            AttachEligibleNeighborBlock(neighborPosition, middleBlock, neighborBlockAttachingVisitor.BlockWasPlacedToTop, neighborBlockAttachingVisitor.BlockWasPlacedToBottom);
        }    

        private void AttachEligibleBottomNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y - 1, position.Z);
            AttachEligibleNeighborBlock(neighborPosition, middleBlock, neighborBlockAttachingVisitor.BlockWasPlacedToBottom, neighborBlockAttachingVisitor.BlockWasPlacedToTop);
        }

        private void AttachEligibleNeighborBlock(BlockPosition neighborPosition, Block middleBlock, Action<Block> neighborBlockPlacementCallback, Action<Block> middleBlockPlacementCallback)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block neighborBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockPlacementCallback(neighborBlock);
                neighborBlock.Visit(neighborBlockAttachingVisitor);
                middleBlockPlacementCallback(middleBlock);
            }
        }
    }
}
