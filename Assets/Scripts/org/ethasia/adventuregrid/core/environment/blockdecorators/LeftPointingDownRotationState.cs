namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class LeftPointingDownRotationState : RotationState
    {
        private static LeftPointingDownRotationState instance;

        public static LeftPointingDownRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new LeftPointingDownRotationState();
            }
            
            return instance;
        }

        private LeftPointingDownRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return LeftPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return LeftPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return FrontPointingDownRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return BackPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return DownPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return UpPointingLeftRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.LEFT_POINTING_DOWN;
        }           
    }
}