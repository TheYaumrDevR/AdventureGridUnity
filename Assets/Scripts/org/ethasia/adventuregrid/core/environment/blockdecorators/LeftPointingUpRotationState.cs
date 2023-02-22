namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class LeftPointingUpRotationState : RotationState
    {
        private static LeftPointingUpRotationState instance;

        public static LeftPointingUpRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new LeftPointingUpRotationState();
            }
            
            return instance;
        }

        private LeftPointingUpRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return LeftPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return LeftPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return FrontPointingUpRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return BackPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return DownPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return UpPointingRightRotationState.GetInstance();
        }
    }
}