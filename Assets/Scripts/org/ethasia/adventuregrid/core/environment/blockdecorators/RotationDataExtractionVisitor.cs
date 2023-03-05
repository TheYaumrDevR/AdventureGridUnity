namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RotationDataExtractionVisitor : BlockDecoratorVisitor
    {
        private static RotationDataExtractionVisitor instance;
        private RotationState extractedRotationState;

        public static RotationDataExtractionVisitor GetInstance()
        {
            if (null == instance)
            {
                instance = new RotationDataExtractionVisitor();
            }
            
            return instance;
        }

        public bool HasRotationState
        {
            get;
            private set;
        }

        private RotationDataExtractionVisitor()
        {

        }

        public RotationState ExtractedRotationState
        {
            get 
            {
                HasRotationState = false;
                return extractedRotationState;
            }

            private set
            {
                extractedRotationState = value;
            }
        }

        public void Accept(RotationDataBlockDecorator visited) 
        {
            ExtractedRotationState = visited.CurrentRotationState;
            HasRotationState = true;
        }

        public void Accept(NeighborAttachingBlockDecorator visited)
        {

        }
    }
}