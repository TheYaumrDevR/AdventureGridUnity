namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class UpPointingLeftRotationState : RotationState
    {
        private static UpPointingLeftRotationState instance;

        public static UpPointingLeftRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new UpPointingLeftRotationState();
            }
            
            return instance;
        }

        private UpPointingLeftRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return BackPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return FrontPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return UpPointingFrontRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return UpPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return LeftPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return RightPointingUpRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.UP_POINTING_LEFT;
        }          
    }
}