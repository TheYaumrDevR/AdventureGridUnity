namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class DownPointingFrontRotationState : RotationState
    {
        private static DownPointingFrontRotationState instance;

        public static DownPointingFrontRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new DownPointingFrontRotationState();
            }
            
            return instance;
        }

        private DownPointingFrontRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return FrontPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return BackPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return DownPointingRightRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return DownPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return RightPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return LeftPointingFrontRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.DOWN_POINTING_FRONT;
        }            
    }
}