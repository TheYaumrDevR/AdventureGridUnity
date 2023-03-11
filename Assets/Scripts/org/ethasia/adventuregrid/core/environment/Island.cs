using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class Island
    {
        public const int HEIGHT_IN_BLOCKS = 256;
        public const int HALF_HEIGHT_IN_BLOCKS = 128;

        private readonly int xzDimension;
        private readonly Block[,,] blocks;

        public bool IsEditable
        {
            get;
            private set;
        }

        public int GetXzDimension()
        {
            return xzDimension;
        }

        public Island(int xzDimension) 
        {
            IsEditable = true;

            this.xzDimension = xzDimension;
            blocks = new Block[xzDimension, HEIGHT_IN_BLOCKS, xzDimension];

            InitializeAllBlocksToAir();
        }

        public Block GetBlockAt(BlockPosition position)
        {
            ThrowExceptionIfBlockPositionIsOutOfBounds(position);
            return blocks[position.X, position.Y, position.Z];
        }

        public void PlaceBlockAt(Block toPlace, BlockPosition position)
        {
            if (IsEditable)
            {
                ThrowExceptionIfBlockPositionIsOutOfBounds(position);
                blocks[position.X, position.Y, position.Z] = toPlace;

                AttachEligibleBlocksToNeighborBlock(position);
            }
        }

        public void SealForPlayerEditing()
        {
            IsEditable = false;
        }

        public bool BlockFaceAtPositionIsHidden(BlockFaceDirections faceType, BlockPosition position)
        {
            int x = position.X;
            int y = position.Y;
            int z = position.Z;

            switch(faceType)
            {
                case BlockFaceDirections.LEFT:
                    if (x < xzDimension - 1) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x + 1, y, z];              
        
                        return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);
                    } 

                    break;
                case BlockFaceDirections.FRONT:
                    if (z < xzDimension - 1) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x, y, z + 1];
                
                        return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);                   
                    }
                
                    break; 
                case BlockFaceDirections.RIGHT:
                    if (x > 0) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x - 1, y, z];
                
                        return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);                   
                    }
                
                    break;    
                case BlockFaceDirections.BACK:
                    if (z > 0) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x, y, z - 1];
                
                        return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);     
                    }
                
                    break;  
                case BlockFaceDirections.BOTTOM:
                    if (y > 0) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x, y - 1, z];
                
                        return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);                    
                    }
                
                    break;      
                case BlockFaceDirections.TOP:                
                    if (y < HEIGHT_IN_BLOCKS - 1) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x, y + 1, z];
                    
                        return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);                    
                    }
                   
                    break;                                                                    
            }

            return false;
        }

        public bool BlockAtPositionIsWalkable(BlockPosition position) 
        {
            Block blockAtGivenPosition = GetBlockAt(position);
            return blockAtGivenPosition.IsWalkable();
        }

        private void InitializeAllBlocksToAir()
        {
            for (int i = 0; i < xzDimension; i++)
            {
                for (int j = 0; j < HEIGHT_IN_BLOCKS; j++)
                {
                    for (int k = 0; k < xzDimension; k++)
                    {
                        blocks[i, j, k] = AirBlock.GetInstance();
                    }
                }
            }
        }

        private void AttachEligibleBlocksToNeighborBlock(BlockPosition position)
        {
            Block middleBlock = blocks[position.X, position.Y, position.Z];

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

            if (!PositionIsOutOfIslandBounds(new BlockPosition(position.X + 1, position.Y, position.Z))) 
            {
                Block leftBlock = blocks[position.X + 1, position.Y, position.Z];
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToLeft(leftBlock);
                leftBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToRight(middleBlock);
            }            
        }

        private void AttachEligibleRightNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();

            if (!PositionIsOutOfIslandBounds(new BlockPosition(position.X - 1, position.Y, position.Z))) 
            {
                Block rightBlock = blocks[position.X - 1, position.Y, position.Z];
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToRight(rightBlock);
                rightBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToLeft(middleBlock); 
            }          
        }

        private void AttachEligibleFrontNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();

            if (!PositionIsOutOfIslandBounds(new BlockPosition(position.X, position.Y, position.Z + 1))) 
            {
                Block frontBlock = blocks[position.X, position.Y, position.Z + 1];
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToFront(frontBlock);
                frontBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBack(middleBlock);  
            }       
        }

        private void AttachEligibleBackNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();

            if (!PositionIsOutOfIslandBounds(new BlockPosition(position.X, position.Y, position.Z - 1))) 
            {
                Block backBlock = blocks[position.X, position.Y, position.Z - 1];
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBack(backBlock);
                backBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToFront(middleBlock);   
            }     
        }    

        private void AttachEligibleTopNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();

            if (!PositionIsOutOfIslandBounds(new BlockPosition(position.X, position.Y + 1, position.Z))) 
            {
                Block topBlock = blocks[position.X, position.Y + 1, position.Z];
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToTop(topBlock);
                topBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBottom(middleBlock); 
            } 
        }    

        private void AttachEligibleBottomNeighborBlock(BlockPosition position, Block middleBlock)
        {
            BlockNeighborPlacingVisitor neighborBlockAttachingVisitor = BlockNeighborPlacingVisitor.GetInstance();

            if (!PositionIsOutOfIslandBounds(new BlockPosition(position.X, position.Y - 1, position.Z))) 
            {
                Block bottomBlock = blocks[position.X, position.Y - 1, position.Z];
                middleBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToBottom(bottomBlock);
                bottomBlock.Visit(neighborBlockAttachingVisitor);
                neighborBlockAttachingVisitor.BlockWasPlacedToTop(middleBlock);  
            }
        }                    
        
        private void ThrowExceptionIfBlockPositionIsOutOfBounds(BlockPosition position) 
        {
            if (PositionIsOutOfIslandBounds(position))
            {
                throw new BlockPositionOutOfBoundsException();
            }            
        }

        private bool PositionIsOutOfIslandBounds(BlockPosition position)
        {
            return position.X >= xzDimension
                || position.Y >= HEIGHT_IN_BLOCKS
                || position.Z >= xzDimension
                || position.X < 0
                || position.Y < 0
                || position.Z < 0;
        }
    }
}