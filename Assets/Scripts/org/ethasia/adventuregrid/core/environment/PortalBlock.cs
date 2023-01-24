namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class PortalBlock : Block
    {
        private PortalBlock() : base(BlockTypes.PORTAL)
        {
            faceHidingStrategy = new TransparentBlockFaceHidingStrategy();
        }

        private static PortalBlock instance;
    
        public static PortalBlock GetInstance() 
        {

            if (null != instance) 
            {
                return instance;
            }        
        
            instance = new PortalBlock();
            return instance;
        }
    
        public override bool GetRightFaceIsCovering() 
        {
            return false;
        }

        public override bool GetFrontFaceIsCovering() 
        {
            return false;
        }

        public override bool GetLeftFaceIsCovering() 
        {
            return false;
        }

        public override bool GetBackFaceIsCovering() 
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