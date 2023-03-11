using Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class WalnutAttachmentPoleBlock : UnvisitableBlock
    {
        private WalnutAttachmentPoleBlock() : base(BlockTypes.WALNUT_WOOD_ATTACHMENT_POLE)
        {
            faceHidingStrategy = new PoleBlockFaceHidingStrategy();
            blockAttachingStrategy = new SignPlateBlockAttachmentStrategy();
        }

        private static WalnutAttachmentPoleBlock instance;

        public static Block GetInstance()
        {
            if (null == instance)
            {
                instance = new WalnutAttachmentPoleBlock();
            }

            return new NeighborAttachingBlockDecorator(instance);
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