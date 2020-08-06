namespace Org.Ethasia.Adventuregrid.Core.Environment 
{
    public class SolidBlockFaceHidingStrategy : IBlockFaceHidingStrategy
    {
        public bool FaceIsHidden(Block coveredBlock, Block coveringBlock, BlockFaceDirections blockFace)
        {
            switch (blockFace)
            {
                case BlockFaceDirections.FRONT:
                    return coveringBlock.GetBackFaceIsCovering() && coveredBlock.GetFrontFaceIsCovering();
                case BlockFaceDirections.RIGHT:
                    return coveringBlock.GetLeftFaceIsCovering() && coveredBlock.GetRightFaceIsCovering();
                case BlockFaceDirections.BACK:
                    return coveringBlock.GetFrontFaceIsCovering() && coveredBlock.GetBackFaceIsCovering();
                case BlockFaceDirections.LEFT:
                    return coveringBlock.GetRightFaceIsCovering() && coveredBlock.GetLeftFaceIsCovering();
                case BlockFaceDirections.BOTTOM:
                    return coveringBlock.GetTopFaceIsCovering() && coveredBlock.GetBottomFaceIsCovering();
                case BlockFaceDirections.TOP:
                    return coveringBlock.GetBottomFaceIsCovering() && coveredBlock.GetTopFaceIsCovering();
            }

            return false;
        }
    }
}