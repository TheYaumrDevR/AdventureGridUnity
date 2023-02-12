namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class WalnutWoodArrowSignplateBlock : Block
    {
        private WalnutWoodArrowSignplateBlock() : base(BlockTypes.WALNUT_WOOD_ARROW_SIGNPLATE)
        {
            faceHidingStrategy = new SignPlateBlockFaceHidingStrategy();
        }

        private static WalnutWoodArrowSignplateBlock instance;

        public static WalnutWoodArrowSignplateBlock GetInstance()
        {
            if (null != instance)
            {
                return instance;
            }

            instance = new WalnutWoodArrowSignplateBlock();
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