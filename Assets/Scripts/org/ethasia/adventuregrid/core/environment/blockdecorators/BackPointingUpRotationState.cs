namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class BackPointingUpRotationState : RotationState
    {
        private static BackPointingUpRotationState instance;

        public static BackPointingUpRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new BackPointingUpRotationState();
            }
            
            return instance;
        }

        private BackPointingUpRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return DownPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return UpPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return LeftPointingUpRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return RightPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return BackPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return BackPointingRightRotationState.GetInstance();
        }
    }
}