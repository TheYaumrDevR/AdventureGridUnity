namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RightPointingUpRotationState : RotationState
    {
        private static RightPointingUpRotationState instance;

        public static RightPointingUpRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new RightPointingUpRotationState();
            }
            
            return instance;
        }

        private RightPointingUpRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return RightPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return RightPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return BackPointingUpRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return FrontPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return UpPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return DownPointingRightRotationState.GetInstance();
        }
    }
}