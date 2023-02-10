namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class WalnutPoleBlockUvCoordinates : BlockUvCoordinates
    {
        private static WalnutPoleBlockUvCoordinates instance;

        public static WalnutPoleBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new WalnutPoleBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            0.6f, 0, 5, 0.6f, 1, 5, 0.4f, 1, 5, 0.4f, 0, 5, // Front 
            0.6f, 0, 5, 0.6f, 1, 5, 0.4f, 1, 5, 0.4f, 0, 5, // Right
            0.6f, 0, 5, 0.6f, 1, 5, 0.4f, 1, 5, 0.4f, 0, 5, // Back
            0.6f, 0, 5, 0.6f, 1, 5, 0.4f, 1, 5, 0.4f, 0, 5, // Left
            0.6f, 0.4f, 5, 0.6f, 0.6f, 5, 0.4f, 0.6f, 5, 0.4f, 0.4f, 5, // Bottom 
            0.6f, 0.4f, 5, 0.6f, 0.6f, 5, 0.4f, 0.6f, 5, 0.4f, 0.4f, 5 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0.4f, 0, 5, 0.4f, 1, 5, 0.6f, 1, 5, 0.6f, 0, 5, // Front
            0.4f, 0, 5, 0.4f, 1, 5, 0.6f, 1, 5, 0.6f, 0, 5, // Right
            0.4f, 0, 5, 0.4f, 1, 5, 0.6f, 1, 5, 0.6f, 0, 5, // Back
            0.4f, 0, 5, 0.4f, 1, 5, 0.6f, 1, 5, 0.6f, 0, 5, // Left
            0.4f, 0.4f, 5, 0.4f, 0.6f, 5, 0.6f, 0.6f, 5, 0.6f, 0.4f, 5, // Bottom 
            0.4f, 0.4f, 5, 0.4f, 0.6f, 5, 0.6f, 0.6f, 5, 0.6f, 0.4f, 5 // Top
        };         

        private WalnutPoleBlockUvCoordinates() {}

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