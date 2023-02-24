using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public abstract class UnvisitableBlock : Block
    {
        protected UnvisitableBlock(BlockTypes blockType) : base(blockType)
        {

        }

        public override void Visit(BlockDecoratorVisitor visitor)
        {

        }
    }
}