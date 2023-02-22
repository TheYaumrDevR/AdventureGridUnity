namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RightPointingDownRotationState : RotationState 
    {
        private static RightPointingDownRotationState instance;

        public static RightPointingDownRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new RightPointingDownRotationState();
            }
            
            return instance;
        }

        private RightPointingDownRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return RightPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return RightPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return BackPointingDownRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return FrontPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return UpPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return DownPointingLeftRotationState.GetInstance();
        }
    }
}