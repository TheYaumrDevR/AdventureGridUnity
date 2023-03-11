
namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{ 
    public class BlockNeighborAttachmentInfoVisitor : BlockDecoratorVisitor
    {
        private static BlockNeighborAttachmentInfoVisitor instance;

        private NeighborAttachingBlockDecorator blockAsttachmentInfo;

        public static BlockNeighborAttachmentInfoVisitor GetInstance()
        {
            if (null == instance)
            {
                instance = new BlockNeighborAttachmentInfoVisitor();
            }
            
            instance.blockAsttachmentInfo = null;
            return instance;
        }

        private BlockNeighborAttachmentInfoVisitor() {}        

        public void Accept(RotationDataBlockDecorator visited) 
        {

        }

        public void Accept(NeighborAttachingBlockDecorator visited)
        {
            blockAsttachmentInfo = visited;
        } 

        public bool IsAttachedToLeftBlock()
        {
            if (null != blockAsttachmentInfo)
            {
                return blockAsttachmentInfo.IsAttachedToLeftBlock;
            }

            return false;
        }

        public bool IsAttachedToRightBlock()
        {
            if (null != blockAsttachmentInfo)
            {
                return blockAsttachmentInfo.IsAttachedToRightBlock;
            }

            return false;
        }   

        public bool IsAttachedToFrontBlock()
        {
            if (null != blockAsttachmentInfo)
            {
                return blockAsttachmentInfo.IsAttachedToFrontBlock;
            }

            return false;
        }  

        public bool IsAttachedToBackBlock()
        {
            if (null != blockAsttachmentInfo)
            {
                return blockAsttachmentInfo.IsAttachedToBackBlock;
            }

            return false;
        }  

        public bool IsAttachedToTopBlock()
        {
            if (null != blockAsttachmentInfo)
            {
                return blockAsttachmentInfo.IsAttachedToTopBlock;
            }

            return false;
        } 

        public bool IsAttachedToBottomBlock()
        {
            if (null != blockAsttachmentInfo)
            {
                return blockAsttachmentInfo.IsAttachedToBottomBlock;
            }

            return false;
        }                                       
    }
}