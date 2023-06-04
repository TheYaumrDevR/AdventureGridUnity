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

        public BlockPosition PlayerSpawnPosition
        {
            get;
            set;
        }

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

                BlockAttacher blockAttacher = new BlockAttacher(this);
                blockAttacher.AttachEligibleBlocksToNeighborBlock(position);
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

            Block currentBlock = blocks[x, y, z];
            Block neighborBlock = null;

            switch(faceType)
            {
                case BlockFaceDirections.LEFT:
                    if (x < xzDimension - 1) 
                    {
                        neighborBlock = blocks[x + 1, y, z];              
                    } 

                    break;
                case BlockFaceDirections.FRONT:
                    if (z < xzDimension - 1) 
                    {
                        neighborBlock = blocks[x, y, z + 1];                
                    }
                
                    break; 
                case BlockFaceDirections.RIGHT:
                    if (x > 0) 
                    {
                        neighborBlock = blocks[x - 1, y, z];                  
                    }
                
                    break;    
                case BlockFaceDirections.BACK:
                    if (z > 0) 
                    {
                        neighborBlock = blocks[x, y, z - 1];    
                    }
                
                    break;  
                case BlockFaceDirections.BOTTOM:
                    if (y > 0) 
                    {
                        neighborBlock = blocks[x, y - 1, z];                   
                    }
                
                    break;      
                case BlockFaceDirections.TOP:                
                    if (y < HEIGHT_IN_BLOCKS - 1) 
                    {
                        neighborBlock = blocks[x, y + 1, z];                   
                    }
                   
                    break;                                                                    
            }

            if (null != neighborBlock)
            {
                return currentBlock.GetFaceHidingStrategy().FaceIsHidden(currentBlock, neighborBlock, faceType);
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
        
        private void ThrowExceptionIfBlockPositionIsOutOfBounds(BlockPosition position) 
        {
            if (PositionIsOutOfIslandBounds(position))
            {
                throw new BlockPositionOutOfBoundsException();
            }            
        }

        public bool PositionIsOutOfIslandBounds(BlockPosition position)
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