namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RotationDataBlockDecorator : IndividualBlockDataDecorator
    {
        private RotationState currentRotationState;

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
            currentRotationState = FrontPointingUpRotationState.GetInstance();
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
                currentRotationState = currentRotationState.RotatePositiveAroundXAxis();
            }
        }

        public void RotateNegativeAroundXAxis()
        {
            if (!LockXAxisRotation)
            {
                currentRotationState = currentRotationState.RotateNegativeAroundXAxis();
            }
        }  

        public void RotatePositiveAroundYAxis()
        {
            if (!LockYAxisRotation)
            {
                currentRotationState = currentRotationState.RotatePositiveAroundYAxis();
            }
        }        

        public void RotateNegativeAroundYAxis()
        {
            if (!LockYAxisRotation)
            {
                currentRotationState = currentRotationState.RotateNegativeAroundYAxis();
            }
        }

        public void RotatePositiveAroundZAxis()
        {
            if (!LockZAxisRotation)
            {
                currentRotationState = currentRotationState.RotatePositiveAroundZAxis();
            }
        }        

        public void RotateNegativeAroundZAxis()
        {
            if (!LockZAxisRotation)
            {
                currentRotationState = currentRotationState.RotateNegativeAroundZAxis();
            }
        }                          
    }
}