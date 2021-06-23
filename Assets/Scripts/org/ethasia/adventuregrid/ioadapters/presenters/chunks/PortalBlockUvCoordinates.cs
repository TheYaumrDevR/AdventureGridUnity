namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class PortalBlockUvCoordinates : BlockUvCoordinates
    {
        private static PortalBlockUvCoordinates instance;
    
        public static PortalBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new PortalBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            0.9375f, 0.046875f, 0.9375f, 0.0625f, 0.875f, 0.0625f, 0.875f, 0.046875f,
            0.9375f, 0.046875f, 0.9375f, 0.0625f, 0.875f, 0.0625f, 0.875f, 0.046875f,
            0.9375f, 0.046875f, 0.9375f, 0.0625f, 0.875f, 0.0625f, 0.875f, 0.046875f,
            0.9375f, 0.046875f, 0.9375f, 0.0625f, 0.875f, 0.0625f, 0.875f, 0.046875f,
            0.9375f, 0.046875f, 0.9375f, 0.0625f, 0.875f, 0.0625f, 0.875f, 0.046875f,
            0.9375f, 0.046875f, 0.9375f, 0.0625f, 0.875f, 0.0625f, 0.875f, 0.046875f,
        };        

        private readonly float[] backUvCoordinates = {
            0.875f, 0.046875f, 0.875f, 0.0625f, 0.9375f, 0.0625f, 0.9375f, 0.046875f,
            0.875f, 0.046875f, 0.875f, 0.0625f, 0.9375f, 0.0625f, 0.9375f, 0.046875f,
            0.875f, 0.046875f, 0.875f, 0.0625f, 0.9375f, 0.0625f, 0.9375f, 0.046875f,
            0.875f, 0.046875f, 0.875f, 0.0625f, 0.9375f, 0.0625f, 0.9375f, 0.046875f,
            0.875f, 0.046875f, 0.875f, 0.0625f, 0.9375f, 0.0625f, 0.9375f, 0.046875f,
            0.875f, 0.046875f, 0.875f, 0.0625f, 0.9375f, 0.0625f, 0.9375f, 0.046875f,
        };        

        private PortalBlockUvCoordinates() {}    

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