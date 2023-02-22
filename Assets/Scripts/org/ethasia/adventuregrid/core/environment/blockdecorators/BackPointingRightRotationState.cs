namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class BackPointingRightRotationState : RotationState
    {
        private static BackPointingRightRotationState instance;

        public static BackPointingRightRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new BackPointingRightRotationState();
            }
            
            return instance;
        }

        private BackPointingRightRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return DownPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return UpPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return LeftPointingBackRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return RightPointingFrontRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return BackPointingUpRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return BackPointingDownRotationState.GetInstance();
        }
    }
}