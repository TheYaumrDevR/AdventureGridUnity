namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class GrassyEarthBlockUvCoordinates : BlockUvCoordinates
    {
        private static GrassyEarthBlockUvCoordinates instance;
    
        public static GrassyEarthBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new GrassyEarthBlockUvCoordinates();
            }
        
            return instance;
        }  

        private readonly float[] uvCoordinates = {
            1, 0, 4, 1, 1, 4, 0, 1, 4, 0, 0, 4, // Front 
            1, 0, 4, 1, 1, 4, 0, 1, 4, 0, 0, 4, // Right
            1, 0, 4, 1, 1, 4, 0, 1, 4, 0, 0, 4, // Back
            1, 0, 4, 1, 1, 4, 0, 1, 4, 0, 0, 4, // Left
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Bottom 
            1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0, 4, 0, 1, 4, 1, 1, 4, 1, 0, 4, // Front
            0, 0, 4, 0, 1, 4, 1, 1, 4, 1, 0, 4, // Right
            0, 0, 4, 0, 1, 4, 1, 1, 4, 1, 0, 4, // Back
            0, 0, 4, 0, 1, 4, 1, 1, 4, 1, 0, 4, // Left
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Bottom 
            0, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0 // Top
        };         

        private GrassyEarthBlockUvCoordinates() {}     

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