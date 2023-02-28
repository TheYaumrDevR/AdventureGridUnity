namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class DownPointingLeftRotationState : RotationState
    {
        private static DownPointingLeftRotationState instance;

        public static DownPointingLeftRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new DownPointingLeftRotationState();
            }
            
            return instance;
        }

        private DownPointingLeftRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return FrontPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return BackPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return DownPointingFrontRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return DownPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return RightPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return LeftPointingUpRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.DOWN_POINTING_LEFT;
        }            
    }
}