namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public interface IBlockFaceHidingStrategy
    {
        bool FaceIsHidden(Block coveredBlock, Block coveringBlock, BlockFaceDirections blockFace);
    }
}