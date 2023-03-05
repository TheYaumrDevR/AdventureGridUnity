namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public interface IBlockAttachingStrategy
    {
        bool AttachesToLeftBlock(Block leftBlock);
        bool AttachesToRightBlock(Block rightBlock);
        bool AttachesToFrontBlock(Block frontBlock);
        bool AttachesToBackBlock(Block backBlock);
        bool AttachesToBottomBlock(Block bottomBlock);
        bool AttachesToTopBlock(Block topBlock);
    }
}
