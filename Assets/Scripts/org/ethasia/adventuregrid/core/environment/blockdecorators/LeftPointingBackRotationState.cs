namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class LeftPointingBackRotationState : RotationState
    {
        private static LeftPointingBackRotationState instance;

        public static LeftPointingBackRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new LeftPointingBackRotationState();
            }
            
            return instance;
        }

        private LeftPointingBackRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return LeftPointingDownRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return LeftPointingUpRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return FrontPointingLeftRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return BackPointingRightRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return DownPointingBackRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return UpPointingBackRotationState.GetInstance();
        }
    }
}