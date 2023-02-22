namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class FrontPointingRightRotationState : RotationState
    {
        private static FrontPointingRightRotationState instance;

        public static FrontPointingRightRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new FrontPointingRightRotationState();
            }
            
            return instance;
        }

        private FrontPointingRightRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return UpPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return DownPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return RightPointingBackRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return LeftPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return FrontPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return FrontPointingDownRotationState.GetInstance();
        }
    }
}