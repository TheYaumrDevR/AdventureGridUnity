namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class ChickweedCropBlockUvCoordinates : BlockUvCoordinates
    {
        private static ChickweedCropBlockUvCoordinates instance;
    
        public static ChickweedCropBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new ChickweedCropBlockUvCoordinates();
            }
        
            return instance;
        }      

        private readonly float[] uvCoordinates = {
            0.9f, 0.2f, 7, 0.9f, 0.4f, 7, 0.1f, 0.4f, 7, 0.1f, 0.2f, 7, // Front 
            0.9f, 0.2f, 7, 0.9f, 0.4f, 7, 0.1f, 0.4f, 7, 0.1f, 0.2f, 7, // Right
            0.9f, 0.2f, 7, 0.9f, 0.4f, 7, 0.1f, 0.4f, 7, 0.1f, 0.2f, 7, // Back
            0.9f, 0.2f, 7, 0.9f, 0.4f, 7, 0.1f, 0.4f, 7, 0.1f, 0.2f, 7, // Left
            0.9f, 0.1f, 7, 0.9f, 0.9f, 7, 0.1f, 0.9f, 7, 0.1f, 0.1f, 7, // Bottom 
            0.9f, 0.1f, 7, 0.9f, 0.9f, 7, 0.1f, 0.9f, 7, 0.1f, 0.1f, 7 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0.1f, 0.2f, 7, 0.1f, 0.4f, 7, 0.9f, 0.4f, 7, 0.9f, 0.2f, 7, // Front
            0.1f, 0.2f, 7, 0.1f, 0.4f, 7, 0.9f, 0.4f, 7, 0.9f, 0.2f, 7, // Right
            0.1f, 0.2f, 7, 0.1f, 0.4f, 7, 0.9f, 0.4f, 7, 0.9f, 0.2f, 7, // Back
            0.1f, 0.2f, 7, 0.1f, 0.4f, 7, 0.9f, 0.4f, 7, 0.9f, 0.2f, 7, // Left
            0.1f, 0.1f, 7, 0.1f, 0.9f, 7, 0.9f, 0.9f, 7, 0.9f, 0.1f, 7, // Bottom 
            0.1f, 0.1f, 7, 0.1f, 0.9f, 7, 0.9f, 0.9f, 7, 0.9f, 0.1f, 7 // Top
        };               

        private ChickweedCropBlockUvCoordinates() {}  

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