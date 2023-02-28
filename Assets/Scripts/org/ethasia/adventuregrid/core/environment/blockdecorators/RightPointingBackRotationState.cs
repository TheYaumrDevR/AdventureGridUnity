namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RightPointingBackRotationState : RotationState
    {
        private static RightPointingBackRotationState instance;

        public static RightPointingBackRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new RightPointingBackRotationState();
            }
            
            return instance;
        }

        private RightPointingBackRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return RightPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return RightPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return BackPointingLeftRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return FrontPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return UpPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return DownPointingBackRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.RIGHT_POINTING_BACK;
        }           
    }
}