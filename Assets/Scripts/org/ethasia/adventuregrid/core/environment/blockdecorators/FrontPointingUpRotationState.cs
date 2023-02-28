namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class FrontPointingUpRotationState : RotationState
    {
        private static FrontPointingUpRotationState instance;

        public static FrontPointingUpRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new FrontPointingUpRotationState();
            }
            
            return instance;
        }

        private FrontPointingUpRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return UpPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return DownPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return RightPointingUpRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return LeftPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return FrontPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return FrontPointingRightRotationState.GetInstance();
        }

        public RotationStates GetRotationIdentifier()
        {
            return RotationStates.FRONT_POINTING_UP;
        }         
    }
}