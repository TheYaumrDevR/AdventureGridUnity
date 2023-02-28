namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RightPointingFrontRotationState : RotationState
    {
        private static RightPointingFrontRotationState instance;

        public static RightPointingFrontRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new RightPointingFrontRotationState();
            }
            
            return instance;
        }

        private RightPointingFrontRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return RightPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return RightPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return BackPointingRightRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return FrontPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return UpPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return DownPointingFrontRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.RIGHT_POINTING_FRONT;
        }          
    }
}