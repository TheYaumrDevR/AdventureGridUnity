namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class LeftPointingFrontRotationState : RotationState
    {
        private static LeftPointingFrontRotationState instance;

        public static LeftPointingFrontRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new LeftPointingFrontRotationState();
            }
            
            return instance;
        }

        private LeftPointingFrontRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return LeftPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return LeftPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return FrontPointingRightRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return BackPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return DownPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return UpPointingFrontRotationState.GetInstance();
        }
    }
}
