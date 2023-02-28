namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class DownPointingBackRotationState : RotationState
    {
        private static DownPointingBackRotationState instance;

        public static DownPointingBackRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new DownPointingBackRotationState();
            }
            
            return instance;
        }

        private DownPointingBackRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return FrontPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return BackPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return DownPointingLeftRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return DownPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return RightPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return LeftPointingBackRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.DOWN_POINTING_BACK;
        }        
    }
}