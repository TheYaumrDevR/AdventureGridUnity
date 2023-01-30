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
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Front 
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Right
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Back
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Left
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2, // Bottom 
            1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Front
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Right
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Back
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Left
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2, // Bottom 
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
    }
}