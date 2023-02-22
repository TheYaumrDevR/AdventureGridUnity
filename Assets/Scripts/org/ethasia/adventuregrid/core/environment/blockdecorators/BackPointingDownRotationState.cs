namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class BackPointingDownRotationState : RotationState
    {
        private static BackPointingDownRotationState instance;

        public static BackPointingDownRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new BackPointingDownRotationState();
            }
            
            return instance;
        }

        private BackPointingDownRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return DownPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return UpPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return LeftPointingDownRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return RightPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return BackPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return BackPointingLeftRotationState.GetInstance();
        }
    }
}