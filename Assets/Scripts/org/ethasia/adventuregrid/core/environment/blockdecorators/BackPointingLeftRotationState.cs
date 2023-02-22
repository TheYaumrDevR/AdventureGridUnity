namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class BackPointingLeftRotationState : RotationState
    {
        private static BackPointingLeftRotationState instance;

        public static BackPointingLeftRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new BackPointingLeftRotationState();
            }
            
            return instance;
        }

        private BackPointingLeftRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return DownPointingLeftRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return UpPointingLeftRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return LeftPointingFrontRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return RightPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return BackPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return BackPointingUpRotationState.GetInstance();
        }
    }
}