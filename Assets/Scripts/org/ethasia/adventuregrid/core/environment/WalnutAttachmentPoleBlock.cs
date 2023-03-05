namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class WalnutAttachmentPoleBlock : UnvisitableBlock
    {
        private WalnutAttachmentPoleBlock() : base(BlockTypes.WALNUT_WOOD_ATTACHMENT_POLE)
        {
            faceHidingStrategy = new PoleBlockFaceHidingStrategy();
        }

        private static WalnutAttachmentPoleBlock instance;

        public static WalnutAttachmentPoleBlock GetInstance()
        {
            if (null != instance)
            {
                return instance;
            }

            instance = new WalnutAttachmentPoleBlock();
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