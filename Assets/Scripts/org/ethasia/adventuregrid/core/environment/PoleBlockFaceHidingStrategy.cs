namespace Org.Ethasia.Adventuregrid.Core.Environment 
{
    public class PoleBlockFaceHidingStrategy : IBlockFaceHidingStrategy
    {
        public bool FaceIsHidden(Block coveredBlock, Block coveringBlock, BlockFaceDirections blockFace)
        {
            switch (blockFace)
            {
                case BlockFaceDirections.FRONT:
                case BlockFaceDirections.RIGHT:
                case BlockFaceDirections.BACK:
                case BlockFaceDirections.LEFT:
                    return false;
                case BlockFaceDirections.BOTTOM:
                    return coveringBlock.GetTopFaceIsCovering() || coveringBlock.GetType().Equals(coveredBlock.GetType());
                case BlockFaceDirections.TOP:
                    return coveringBlock.GetBottomFaceIsCovering() || coveringBlock.GetType().Equals(coveredBlock.GetType());
            }

            return false;
        }
    }
}