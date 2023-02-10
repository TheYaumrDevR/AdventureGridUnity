namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class WalnutPoleBlock : Block
    {
        private WalnutPoleBlock() : base(BlockTypes.WALNUT_WOOD_POLE)
        {
            faceHidingStrategy = new PoleBlockFaceHidingStrategy();
        }

        private static WalnutPoleBlock instance;

        public static WalnutPoleBlock GetInstance()
        {
            if (null != instance)
            {
                return instance;
            }

            instance = new WalnutPoleBlock();
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
            return true;
        }
    }
}