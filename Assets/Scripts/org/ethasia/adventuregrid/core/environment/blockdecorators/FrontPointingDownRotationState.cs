namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class FrontPointingDownRotationState : RotationState
    {
        private static FrontPointingDownRotationState instance;

        public static FrontPointingDownRotationState GetInstance()
        {
            if (null == instance)
            {
                instance = new FrontPointingDownRotationState();
            }
            
            return instance;
        }

        private FrontPointingDownRotationState()
        {

        }

        public RotationState RotatePositiveAroundXAxis()
        {
            return UpPointingFrontRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundXAxis()
        {
            return DownPointingBackRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundYAxis()
        {
            return RightPointingDownRotationState.GetInstance();
        }   

        public RotationState RotateNegativeAroundYAxis()
        {
            return LeftPointingDownRotationState.GetInstance();
        }

        public RotationState RotatePositiveAroundZAxis()
        {
            return FrontPointingRightRotationState.GetInstance();
        }

        public RotationState RotateNegativeAroundZAxis()
        {
            return FrontPointingLeftRotationState.GetInstance();
        }
    }
}