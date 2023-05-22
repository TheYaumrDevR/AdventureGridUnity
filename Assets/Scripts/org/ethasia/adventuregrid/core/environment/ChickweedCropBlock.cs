namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class ChickweedCropBlock : UnvisitableBlock
    {
        private ChickweedCropBlock() : base(BlockTypes.CHICKWEED_CROP)
        {
            faceHidingStrategy = new CropBlockFaceHidingStrategy();
        }   

        private static ChickweedCropBlock instance;

        public static ChickweedCropBlock GetInstance() 
        {
            if (null != instance) 
            {
                return instance;
            }

            instance = new ChickweedCropBlock();
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