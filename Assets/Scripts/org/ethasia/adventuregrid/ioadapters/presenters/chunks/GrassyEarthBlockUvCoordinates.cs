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
            0.125f, 0.015625f, 0.125f, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Front
            0.125f, 0.015625f, 0.125f, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Right
            0.125f, 0.015625f, 0.125f, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Back
            0.125f, 0.015625f, 0.125f, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Left
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Bottom 
            0.1875f, 0.015625f, 0.1875f, 0, 0.125f, 0, 0.125f, 0.015625f // Top
        };
    
        private readonly float[] backUvCoordinates = {
            0.0625f, 0.015625f, 0.0625f, 0, 0.125f, 0, 0.125f, 0.015625f, // Front
            0.0625f, 0.015625f, 0.0625f, 0, 0.125f, 0, 0.125f, 0.015625f, // Right
            0.0625f, 0.015625f, 0.0625f, 0, 0.125f, 0, 0.125f, 0.015625f, // Back
            0.0625f, 0.015625f, 0.0625f, 0, 0.125f, 0, 0.125f, 0.015625f, // Left
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Bottom 
            0.125f, 0.015625f, 0.125f, 0, 0.1875f, 0, 0.1875f, 0.015625f // Top
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