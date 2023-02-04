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
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Front 
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Right
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Back
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Left
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3, // Bottom 
            1, 0, 3, 1, 1, 3, 0, 1, 3, 0, 0, 3 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Front
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Right
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Back
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Left
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3, // Bottom 
            0, 0, 3, 0, 1, 3, 1, 1, 3, 1, 0, 3 // Top
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