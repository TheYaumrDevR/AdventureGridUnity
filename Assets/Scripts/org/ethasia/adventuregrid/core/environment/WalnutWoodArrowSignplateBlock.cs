namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class WalnutWoodArrowSignplateBlock : Block
    {
        private WalnutWoodArrowSignplateBlock() : base(BlockTypes.WALNUT_WOOD_ARROW_SIGNPLATE)
        {
            faceHidingStrategy = new SignPlateBlockFaceHidingStrategy();
        }

        private static Block instance;

        public static Block GetInstance()
        {
            if (null != instance)
            {
                return new RotationDataBlockDecorator(instance);
            }

            instance = new WalnutWoodArrowSignplateBlock();
            return new RotationDataBlockDecorator(instance);
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