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

        public Block GetBlockAt(int x, int y, int z)
        {
            if (PositionIsOutOfIslandBounds(x, y, z))
            {
                throw new BlockPositionOutOfBoundsException();
            }

            return blocks[x, y, z];
        }

        public void PlaceBlockAt(Block toPlace, int x, int y, int z)
        {
            if (PositionIsOutOfIslandBounds(x, y, z))
            {
                throw new BlockPositionOutOfBoundsException();
            }

            blocks[x, y, z] = toPlace;
        }

        public bool BlockFaceAtPositionIsHidden(BlockFaceDirections faceType, int x, int y, int z)
        {
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

        private bool PositionIsOutOfIslandBounds(int x, int y, int z)
        {
            return x >= xzDimension
                || y >= HEIGHT_IN_BLOCKS
                || z >= xzDimension;
        }
    }
}