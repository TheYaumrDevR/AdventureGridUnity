namespace Org.Ethasia.Adventuregrid.Core.Environment 
{
    public class CropBlockFaceHidingStrategy : IBlockFaceHidingStrategy
    {
        public bool FaceIsHidden(Block coveredBlock, Block coveringBlock, BlockFaceDirections blockFace)
        {
            switch (blockFace)
            {
                case BlockFaceDirections.FRONT:
                    return false;
                case BlockFaceDirections.RIGHT:
                    return false;
                case BlockFaceDirections.BACK:
                    return false;
                case BlockFaceDirections.LEFT:
                    return false;
                case BlockFaceDirections.BOTTOM:
                    return coveringBlock.GetTopFaceIsCovering();
                case BlockFaceDirections.TOP:
                    return false;
            }

            return false;
        }
    }
}