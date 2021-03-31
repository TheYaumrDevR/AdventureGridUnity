using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class Island
    {
        public const int HEIGHT_IN_BLOCKS = 256;

        private readonly int xzDimension;
        private readonly Block[,,] blocks;

        public int GetXzDimension()
        {
            return xzDimension;
        }

        public Island(int xzDimension) 
        {
            this.xzDimension = xzDimension;
            blocks = new Block[xzDimension, HEIGHT_IN_BLOCKS, xzDimension];

            InitializeAllBlocksToAir();
        }

        public Block GetBlockAt(BlockPosition position)
        {
            if (PositionIsOutOfIslandBounds(position))
            {
                throw new BlockPositionOutOfBoundsException();
            }

            return blocks[position.X, position.Y, position.Z];
        }

        public void PlaceBlockAt(Block toPlace, BlockPosition position)
        {
            if (PositionIsOutOfIslandBounds(position))
            {
                throw new BlockPositionOutOfBoundsException();
            }

            blocks[position.X, position.Y, position.Z] = toPlace;
        }

        public bool BlockFaceAtPositionIsHidden(BlockFaceDirections faceType, BlockPosition position)
        {
            int x = position.X;
            int y = position.Y;
            int z = position.Z;

            switch(faceType)
            {
                case BlockFaceDirections.LEFT:
                    if (x > 0) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x - 1, y, z];              
        
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
                    if (x < xzDimension - 1) 
                    {
                        Block currentBlock = blocks[x, y, z];
                        Block neighborBlock = blocks[x + 1, y, z];
                
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

        private bool PositionIsOutOfIslandBounds(BlockPosition position)
        {
            return position.X >= xzDimension
                || position.Y >= HEIGHT_IN_BLOCKS
                || position.Z >= xzDimension;
        }
    }
}