namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class EarthBlock : UnvisitableBlock
    {
        private EarthBlock() : base(BlockTypes.EARTH)
        {
            faceHidingStrategy = new SolidBlockFaceHidingStrategy();
        }   

        private static EarthBlock instance;

        public static EarthBlock GetInstance() 
        {
            if (null != instance) 
            {
                return instance;
            }

            instance = new EarthBlock();
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