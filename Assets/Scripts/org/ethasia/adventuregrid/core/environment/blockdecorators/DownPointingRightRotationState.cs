namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class DownPointingRightRotationState : RotationState
    {
        private static DownPointingRightRotationState instance;

        public static DownPointingRightRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new DownPointingRightRotationState();
            }
            
            return instance;
        }

        private DownPointingRightRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return FrontPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return BackPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return DownPointingBackRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return DownPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return RightPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return LeftPointingDownRotationState.GetInstance();
        }
    }
}