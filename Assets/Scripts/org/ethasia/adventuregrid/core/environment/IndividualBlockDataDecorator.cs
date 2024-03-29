namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public abstract class IndividualBlockDataDecorator : Block
    {
        protected Block decoratedBlock;

        public IndividualBlockDataDecorator(Block decoratedBlock) : base(decoratedBlock.GetBlockType())
        {
            this.decoratedBlock = decoratedBlock;
            
            faceHidingStrategy = decoratedBlock.GetFaceHidingStrategy();
            blockAttachingStrategy = decoratedBlock.GetBlockAttachingStrategy();
        }
    }
}