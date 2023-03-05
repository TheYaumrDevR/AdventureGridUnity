namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class NeighborAttachingBlockDecorator : IndividualBlockDataDecorator
    {
        public bool IsAttachedToLeftBlock
        {
            get;
            private set;
        }

        public bool IsAttachedToRightBlock
        {
            get;
            private set;
        }

        public bool IsAttachedToFrontBlock
        {
            get;
            private set;
        }

        public bool IsAttachedToBackBlock
        {
            get;
            private set;
        }   

        public bool IsAttachedToUpBlock
        {
            get;
            private set;
        }

        public bool IsAttachedToDownBlock
        {
            get;
            private set;
        }                             

        public NeighborAttachingBlockDecorator(Block decoratedBlock) : base(decoratedBlock)
        {           
            faceHidingStrategy = decoratedBlock.GetFaceHidingStrategy();
        }

        public override bool GetFrontFaceIsCovering() 
        {
            return decoratedBlock.GetFrontFaceIsCovering();
        }

        public override bool GetRightFaceIsCovering()
        {
            return decoratedBlock.GetRightFaceIsCovering();
        }

        public override bool GetBackFaceIsCovering()
        {
            return decoratedBlock.GetBackFaceIsCovering();
        }

        public override bool GetLeftFaceIsCovering()
        {
            return decoratedBlock.GetLeftFaceIsCovering();
        }

        public override bool GetBottomFaceIsCovering()
        {
            return decoratedBlock.GetBottomFaceIsCovering();
        }

        public override bool GetTopFaceIsCovering()
        {
            return decoratedBlock.GetTopFaceIsCovering();
        }         

        public override bool IsWalkable()
        {
            return decoratedBlock.IsWalkable();
        } 

        public override void Visit(BlockDecoratorVisitor visitor)   
        {
            visitor.Accept(this);
            decoratedBlock.Visit(visitor);
        }          
    }
}