namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class RockBlockUvCoordinates : BlockUvCoordinates
    {
        private static RockBlockUvCoordinates instance;
    
        public static RockBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new RockBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, // Front 
            1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, // Right
            1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, // Back
            1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, // Left
            1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, // Bottom 
            1, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, // Front
            0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, // Right
            0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, // Back
            0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, // Left
            0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, // Bottom 
            0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1 // Top
        };         

        private RockBlockUvCoordinates() {}

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