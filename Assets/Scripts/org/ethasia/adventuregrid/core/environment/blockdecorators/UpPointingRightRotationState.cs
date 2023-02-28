namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class UpPointingRightRotationState : RotationState
    {
        private static UpPointingRightRotationState instance;

        public static UpPointingRightRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new UpPointingRightRotationState();
            }
            
            return instance;
        }

        private UpPointingRightRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return BackPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return FrontPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return UpPointingBackRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return UpPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return LeftPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return RightPointingDownRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.UP_POINTING_RIGHT;
        }          
    }
}