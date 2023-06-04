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

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block leftBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToLeft(leftBlock);
                leftBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToRight(middleBlock);
            }            
        }

        private void AttachEligibleRightNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X - 1, position.Y, position.Z);

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block rightBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToRight(rightBlock);
                rightBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToLeft(middleBlock); 
            }          
        }

        private void AttachEligibleFrontNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y, position.Z + 1);

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block frontBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToFront(frontBlock);
                frontBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBack(middleBlock);  
            }       
        }

        private void AttachEligibleBackNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y, position.Z - 1);

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block backBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBack(backBlock);
                backBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToFront(middleBlock);   
            }     
        }    

        private void AttachEligibleTopNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y + 1, position.Z);

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block topBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToTop(topBlock);
                topBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBottom(middleBlock); 
            } 
        }    

        private void AttachEligibleBottomNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();
            BlockPosition neighborPosition = new BlockPosition(position.X, position.Y - 1, position.Z);

            if (!island.PositionIsOutOfIslandBounds(neighborPosition)) 
            {
                Block bottomBlock = island.GetBlockAt(neighborPosition);
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBottom(bottomBlock);
                bottomBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToTop(middleBlock);  
            }
        }
    }
}
