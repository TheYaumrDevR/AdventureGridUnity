namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class UpPointingBackRotationState : RotationState
    {
        private static UpPointingBackRotationState instance;

        public static UpPointingBackRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new UpPointingBackRotationState();
            }
            
            return instance;
        }

        private UpPointingBackRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return BackPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return FrontPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return UpPointingLeftRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return UpPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return LeftPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return RightPointingBackRotationState.GetInstance();
        }
    }
}