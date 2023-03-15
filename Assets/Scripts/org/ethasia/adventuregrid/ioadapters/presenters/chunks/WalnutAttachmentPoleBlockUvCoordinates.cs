namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class WalnutAttachmentPoleBlockUvCoordinates : BlockUvCoordinates
    {
        private static WalnutAttachmentPoleBlockUvCoordinates instance;

        public static WalnutAttachmentPoleBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new WalnutAttachmentPoleBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Front 
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Right
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Back
            0.65f, 0, 5, 0.65f, 1, 5, 0.35f, 1, 5, 0.35f, 0, 5, // Left
            0.65f, 0.4f, 5, 0.65f, 0.6f, 5, 0.35f, 0.6f, 5, 0.35f, 0.4f, 5, // Bottom 
            0.65f, 0.4f, 5, 0.65f, 0.6f, 5, 0.35f, 0.6f, 5, 0.35f, 0.4f, 5 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Front
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Right
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Back
            0.35f, 0, 5, 0.35f, 1, 5, 0.65f, 1, 5, 0.65f, 0, 5, // Left
            0.35f, 0.4f, 5, 0.35f, 0.6f, 5, 0.65f, 0.6f, 5, 0.65f, 0.4f, 5, // Bottom 
            0.35f, 0.4f, 5, 0.35f, 0.6f, 5, 0.65f, 0.6f, 5, 0.65f, 0.4f, 5 // Top
        }; 

        private readonly float[] uvCoordinatesLeftAttachment = {
            0.35f, 0.29f, 5, 0.35f, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Front 
            0, 0.29f, 5, 0, 0.65f, 5, 0.35f, 0.65f, 5, 0.35f, 0.29f, 5,  // Back
            0.35f, 0.45f, 5, 0.35f, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5, // Bottom 
            0.35f, 0.45f, 5, 0.35f, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5 // Top
        };         

        private readonly float[] backUvCoordinatesLeftAttachment = {
            0, 0.29f, 5, 0, 0.65f, 5, 0.35f, 0.65f, 5, 0.35f, 0.29f, 5, // Front
            0.35f, 0.29f, 5, 0.35f, 0.65f, 5, 0, 0.65f, 5, 0, 0.29f, 5, // Back
            0, 0.45f, 5, 0, 0.55f, 5, 0.35f, 0.55f, 5, 0.35f, 0.45f, 5, // Bottom 
            0, 0.45f, 5, 0, 0.55f, 5, 0.35f, 0.55f, 5, 0.35f, 0.45f, 5 // Top
        };                

        private WalnutAttachmentPoleBlockUvCoordinates() {}

        public override float[] GetUvCoordinates() 
        {
            return uvCoordinates;
        }
    
        public override float[] GetBackUvCoordinates() 
        {
            return backUvCoordinates;
        }
    }
}