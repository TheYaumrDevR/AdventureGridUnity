namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class FrontPointingLeftRotationState : RotationState
    {
        private static FrontPointingLeftRotationState instance;

        public static FrontPointingLeftRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new FrontPointingLeftRotationState();
            }
            
            return instance;
        }

        private FrontPointingLeftRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return UpPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return DownPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return RightPointingFrontRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return LeftPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return FrontPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return FrontPointingUpRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.FRONT_POINTING_LEFT;
        }         
    }
}