namespace Org.Ethasia.Adventuregrid.Core.Environment 
{
    public class SignPlateBlockFaceHidingStrategy : IBlockFaceHidingStrategy
    {
        public bool FaceIsHidden(Block coveredBlock, Block coveringBlock, BlockFaceDirections blockFace)
        {
            switch (blockFace)
            {
                case BlockFaceDirections.BACK:
                case BlockFaceDirections.FRONT:
                case BlockFaceDirections.BOTTOM:
                case BlockFaceDirections.TOP:
                    return false;
                case BlockFaceDirections.RIGHT:
                    return coveringBlock.GetLeftFaceIsCovering() || coveringBlock.GetType().Equals(coveredBlock.GetType());
                case BlockFaceDirections.LEFT:
                    return coveringBlock.GetRightFaceIsCovering() || coveringBlock.GetType().Equals(coveredBlock.GetType());
            }

            return false;
        }
    }
}