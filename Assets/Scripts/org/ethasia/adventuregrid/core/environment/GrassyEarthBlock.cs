namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class GrassyEarthBlock : UnvisitableBlock
    {
        private GrassyEarthBlock() : base(BlockTypes.GRASSY_EARTH)
        {
            faceHidingStrategy = new SolidBlockFaceHidingStrategy();
        }

        private static GrassyEarthBlock instance;

        public static GrassyEarthBlock GetInstance()
        {
            if (null != instance)
            {
                return instance;
            }

            instance = new GrassyEarthBlock();
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