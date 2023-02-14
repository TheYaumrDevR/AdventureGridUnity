namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class RotationDataBlockDecorator : IndividualBlockDataDecorator
    {
        public RotationDataBlockDecorator(Block decoratedBlock) : base(decoratedBlock)
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
    }
}