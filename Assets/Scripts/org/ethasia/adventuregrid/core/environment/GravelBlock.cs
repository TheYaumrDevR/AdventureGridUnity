namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class GravelBlock : Block
    {
        private GravelBlock() : base(BlockTypes.GRAVEL)
        {
            faceHidingStrategy = new SolidBlockFaceHidingStrategy();
        }

        private static GravelBlock instance;

        public static GravelBlock GetInstance()
        {
            if (null != instance)
            {
                return instance;
            }

            instance = new GravelBlock();
            return instance;
        }

        public override bool GetFrontFaceIsCovering() 
        {
            return true;
        }

        public override bool GetRightFaceIsCovering()
        {
            return true;
        }

        public override bool GetBackFaceIsCovering()
        {
            return true;
        }

        public override bool GetLeftFaceIsCovering()
        {
            return true;
        }

        public override bool GetBottomFaceIsCovering()
        {
            return true;
        }

        public override bool GetTopFaceIsCovering()
        {
            return true;
        }         

        public override bool IsWalkable()
        {
            return true;
        }
    }
}
