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

        public bool IsAttachedToTopBlock
        {
            get;
            private set;
        }

        public bool IsAttachedToBottomBlock
        {
            get;
            private set;
        }                             

        public NeighborAttachingBlockDecorator(Block decoratedBlock) : base(decoratedBlock) {}

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

        public void BlockWasPlacedToLeft(Block leftNeighbor)
        {
            if (null != blockAttachingStrategy)
            {
                IsAttachedToLeftBlock = blockAttachingStrategy.AttachesToLeftBlock(leftNeighbor);
            }
        }

        public void BlockWasPlacedToRight(Block leftNeighbor)
        {
            if (null != blockAttachingStrategy)
            {
                IsAttachedToRightBlock = blockAttachingStrategy.AttachesToRightBlock(leftNeighbor);
            }
        }    

        public void BlockWasPlacedToFront(Block leftNeighbor)
        {
            if (null != blockAttachingStrategy)
            {
                IsAttachedToFrontBlock = blockAttachingStrategy.AttachesToFrontBlock(leftNeighbor);
            }
        }           

        public void BlockWasPlacedToBack(Block leftNeighbor)
        {
            if (null != blockAttachingStrategy)
            {
                IsAttachedToBackBlock = blockAttachingStrategy.AttachesToBackBlock(leftNeighbor);
            }
        }         

        public void BlockWasPlacedToTop(Block leftNeighbor)
        {
            if (null != blockAttachingStrategy)
            {
                IsAttachedToTopBlock = blockAttachingStrategy.AttachesToTopBlock(leftNeighbor);
            }
        }  

        public void BlockWasPlacedToBottom(Block leftNeighbor)
        {
            if (null != blockAttachingStrategy)
            {
                IsAttachedToBottomBlock = blockAttachingStrategy.AttachesToBottomBlock(leftNeighbor);
            }
        }                

        public override void Visit(BlockDecoratorVisitor visitor)   
        {
            visitor.Accept(this);
            decoratedBlock.Visit(visitor);
        }          
    }
}