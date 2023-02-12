namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class WalnutWoodArrowSignplateBlockUvCoordinates : BlockUvCoordinates
    {
        private static WalnutWoodArrowSignplateBlockUvCoordinates instance;

        public static WalnutWoodArrowSignplateBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new WalnutWoodArrowSignplateBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            1, 0.29f, 6, 1, 0.65f, 6, 0, 0.65f, 6, 0, 0.29f, 6, // Front 
            0.55f, 0.29f, 5, 0.55f, 0.65f, 5, 0.45f, 0.65f, 5, 0.45f, 0.29f, 5, // Right
            0, 0.29f, 6, 0, 0.65f, 6, 1, 0.65f, 6, 1, 0.29f, 6,  // Back
            0.55f, 0.29f, 5, 0.55f, 0.65f, 5, 0.45f, 0.65f, 5, 0.45f, 0.29f, 5, // Left
            1, 0.45f, 5, 1, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5, // Bottom 
            1, 0.45f, 5, 1, 0.55f, 5, 0, 0.55f, 5, 0, 0.45f, 5 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0.29f, 6, 0, 0.65f, 6, 1, 0.65f, 6, 1, 0.29f, 6, // Front
            0.45f, 0.29f, 5, 0.45f, 0.65f, 5, 0.55f, 0.65f, 5, 0.55f, 0.29f, 5, // Right
            1, 0.29f, 6, 1, 0.65f, 6, 0, 0.65f, 6, 0, 0.29f, 6, // Back
            0.45f, 0.29f, 5, 0.45f, 0.65f, 5, 0.55f, 0.65f, 5, 0.55f, 0.29f, 5, // Left
            0, 0.45f, 5, 0, 0.55f, 5, 1, 0.55f, 5, 1, 0.45f, 5, // Bottom 
            0, 0.45f, 5, 0, 0.55f, 5, 1, 0.55f, 5, 1, 0.45f, 5 // Top
        };         

        private WalnutWoodArrowSignplateBlockUvCoordinates() {}

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