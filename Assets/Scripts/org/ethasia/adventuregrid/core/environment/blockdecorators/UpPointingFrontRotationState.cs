namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class UpPointingFrontRotationState : RotationState
    {
        private static UpPointingFrontRotationState instance;

        public static UpPointingFrontRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new UpPointingFrontRotationState();
            }
            
            return instance;
        }

        private UpPointingFrontRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return BackPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return FrontPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return UpPointingRightRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return UpPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return LeftPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return RightPointingFrontRotationState.GetInstance();
        }
    }
}