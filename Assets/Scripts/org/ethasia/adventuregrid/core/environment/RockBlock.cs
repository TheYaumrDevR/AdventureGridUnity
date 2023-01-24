namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class RockBlock : Block
    {
        private RockBlock() : base(BlockTypes.ROCK)
        {
            faceHidingStrategy = new SolidBlockFaceHidingStrategy();
        }

        private static RockBlock instance;

        public static RockBlock GetInstance()
        {
            if (null != instance)
            {
                return instance;
            }

            instance = new RockBlock();
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