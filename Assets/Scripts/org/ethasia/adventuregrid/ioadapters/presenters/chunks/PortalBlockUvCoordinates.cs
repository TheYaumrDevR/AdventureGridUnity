namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class PortalBlockUvCoordinates : BlockUvCoordinates
    {
        private static PortalBlockUvCoordinates instance;
    
        public static PortalBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new PortalBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            1, 0, 1, 1, 0, 1, 0, 0, // Front 
            1, 0, 1, 1, 0, 1, 0, 0, // Right
            1, 0, 1, 1, 0, 1, 0, 0, // Back
            1, 0, 1, 1, 0, 1, 0, 0, // Left
            1, 0, 1, 1, 0, 1, 0, 0, // Bottom 
            1, 0, 1, 1, 0, 1, 0, 0 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0, 0, 1, 1, 1, 1, 0, // Front
            0, 0, 0, 1, 1, 1, 1, 0, // Right
            0, 0, 0, 1, 1, 1, 1, 0, // Back
            0, 0, 0, 1, 1, 1, 1, 0, // Left
            0, 0, 0, 1, 1, 1, 1, 0, // Bottom 
            0, 0, 0, 1, 1, 1, 1, 0 // Top
        };       

        private PortalBlockUvCoordinates() {}    

        public override float[] GetUvCoordinates() 
        {
            return uvCoordinates;
        } 
    
        public override float[] GetBackUvCoordinates() 
        {
            return backUvCoordinates;
        }  

        public override float[] GetUvCoordinatesForAttachmentState(BlockAttachmentState attachmentState) 
        {                              
            return uvCoordinates;
        }
    
        public override float[] GetBackUvCoordinatesForAttachmentState(BlockAttachmentState attachmentState) 
        {
            return backUvCoordinates;
        }                          
    }
}