namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class AirBlock : Block
    {
        private AirBlock() : base(BlockTypes.AIR)
        {
            faceHidingStrategy = new SolidBlockFaceHidingStrategy();
        }

        private static AirBlock instance;

        public static AirBlock GetInstance()
        {
            if (null != instance) 
            {
                return instance;
            }

            instance = new AirBlock();
            return instance;
        }

        public override bool GetFrontFaceIsCovering() 
        {
            return false;
        }

        public override bool GetRightFaceIsCovering()
        {
            return false;
        }

        public override bool GetBackFaceIsCovering()
        {
            return false;
        }

        public override bool GetLeftFaceIsCovering()
        {
            return false;
        }

        public override bool GetBottomFaceIsCovering()
        {
            return false;
        }

        public override bool GetTopFaceIsCovering()
        {
            return false;
        }

        public override bool IsWalkable()
        {
            return false;
        }
    }
}