namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class EarthBlockUvCoordinates : BlockUvCoordinates
    {
        private static EarthBlockUvCoordinates instance;
    
        public static EarthBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new EarthBlockUvCoordinates();
            }
        
            return instance;
        }      

        private readonly float[] uvCoordinates = {
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Front
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Right
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Back
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Left
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Bottom  
            0.0625f, 0, 0.0625f, 0.015625f, 0, 0.015625f, 0, 0, // Top
        };        

        private readonly float[] backUvCoordinates = {
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Front
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Right
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Back
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Left
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Bottom  
            0, 0, 0, 0.015625f, 0.0625f, 0.015625f, 0.0625f, 0, // Top
        };                 

        private EarthBlockUvCoordinates() {}  

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