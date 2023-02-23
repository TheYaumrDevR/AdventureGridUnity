using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public abstract class IndividualBlockDataDecorator : Block
    {
        protected Block decoratedBlock;

        public IndividualBlockDataDecorator(Block decoratedBlock) : base(decoratedBlock.GetBlockType())
        {
            this.decoratedBlock = decoratedBlock;
        }

        public abstract void Visit(BlockDecoratorVisitor visitor); 
    }
}