namespace Org.Ethasia.Adventuregrid.Core.Environment 
{
    public class TransparentBlockFaceHidingStrategy : IBlockFaceHidingStrategy
    {
        public bool FaceIsHidden(Block coveredBlock, Block coveringBlock, BlockFaceDirections blockFace)
        {
            return coveringBlock.GetBlockType() != BlockTypes.AIR;
        }
    }
}