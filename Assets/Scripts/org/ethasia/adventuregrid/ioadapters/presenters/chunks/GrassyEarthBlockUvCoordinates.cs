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
            0.125f, 0, 0.125f, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Front 
            0.125f, 0, 0.125f, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Right
            0.125f, 0, 0.125f, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Back
            0.125f, 0, 0.125f, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Left
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Bottom 
            0.1875f, 0, 0.1875f, 0.015625f, 0.125f, 0.015625f, 0.125f, 0 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0.0625f, 0, 0.0625f, 0.015625f, 0.125f, 0.015625f, 0.125f, 0, // Front
            0.0625f, 0, 0.0625f, 0.015625f, 0.125f, 0.015625f, 0.125f, 0, // Right
            0.0625f, 0, 0.0625f, 0.015625f, 0.125f, 0.015625f, 0.125f, 0, // Back
            0.0625f, 0, 0.0625f, 0.015625f, 0.125f, 0.015625f, 0.125f, 0, // Left
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Bottom 
            0.125f, 0, 0.125f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0 // Top
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