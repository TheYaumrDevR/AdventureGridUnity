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
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Front
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Right
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Back
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Left
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Bottom  
            0.0625f, 0.015625f, 0.0625f, 0, 0, 0, 0, 0.015625f, // Top
        };
    
        private readonly float[] backUvCoordinates = {
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Front
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Right
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Back
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Left
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Bottom  
            0, 0.015625f, 0, 0, 0.0625f, 0, 0.0625f, 0.015625f, // Top
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