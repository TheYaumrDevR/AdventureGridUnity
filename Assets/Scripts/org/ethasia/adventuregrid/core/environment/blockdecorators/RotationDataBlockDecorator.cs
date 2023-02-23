namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RotationDataBlockDecorator : IndividualBlockDataDecorator
    {
        public RotationState CurrentRotationState
        {
            get;
            private set;
        }

        public bool LockXAxisRotation
        {
            private get;
            set;
        }

        public bool LockYAxisRotation
        {
            private get;
            set;
        }

        public bool LockZAxisRotation
        {
            private get;
            set;
        }                

        public RotationDataBlockDecorator(Block decoratedBlock) : base(decoratedBlock)
        {           
            faceHidingStrategy = decoratedBlock.GetFaceHidingStrategy();
            CurrentRotationState = FrontPointingUpRotationState.GetInstance();
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

        public void RotatePositiveAroundXAxis()
        {
            if (!LockXAxisRotation)
            {
                CurrentRotationState = CurrentRotationState.RotatePositiveAroundXAxis();
            }
        }

        public void RotateNegativeAroundXAxis()
        {
            if (!LockXAxisRotation)
            {
                CurrentRotationState = CurrentRotationState.RotateNegativeAroundXAxis();
            }
        }  

        public void RotatePositiveAroundYAxis()
        {
            if (!LockYAxisRotation)
            {
                CurrentRotationState = CurrentRotationState.RotatePositiveAroundYAxis();
            }
        }        

        public void RotateNegativeAroundYAxis()
        {
            if (!LockYAxisRotation)
            {
                CurrentRotationState = CurrentRotationState.RotateNegativeAroundYAxis();
            }
        }

        public void RotatePositiveAroundZAxis()
        {
            if (!LockZAxisRotation)
            {
                CurrentRotationState = CurrentRotationState.RotatePositiveAroundZAxis();
            }
        }        

        public void RotateNegativeAroundZAxis()
        {
            if (!LockZAxisRotation)
            {
                CurrentRotationState = CurrentRotationState.RotateNegativeAroundZAxis();
            }
        }

        public override void Visit(BlockDecoratorVisitor visitor)   
        {
            visitor.Accept(this);
        }                       
    }
}