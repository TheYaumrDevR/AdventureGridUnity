namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public abstract class Block
    {
        protected readonly BlockTypes blockType;
        protected IBlockFaceHidingStrategy faceHidingStrategy;

        public BlockTypes GetBlockType() 
        {
            return blockType;
        }

        public IBlockFaceHidingStrategy GetFaceHidingStrategy() 
        {
            return faceHidingStrategy;
        }

        public Block(BlockTypes blockType) 
        {
            this.blockType = blockType;
        }

        public abstract bool GetFrontFaceIsCovering();
        public abstract bool GetRightFaceIsCovering();
        public abstract bool GetBackFaceIsCovering();
        public abstract bool GetLeftFaceIsCovering();
        public abstract bool GetBottomFaceIsCovering();
        public abstract bool GetTopFaceIsCovering();
    }
}