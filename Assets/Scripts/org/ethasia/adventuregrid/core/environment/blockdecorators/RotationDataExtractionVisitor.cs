namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RotationDataExtractionVisitor : BlockDecoratorVisitor
    {
        private static RotationDataExtractionVisitor instance;

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
                return ExtractedRotationState;
            }

            private set
            {
                ExtractedRotationState = value;
            }
        }

        public void Accept(RotationDataBlockDecorator visited) 
        {
            ExtractedRotationState = visited.CurrentRotationState;
            HasRotationState = true;
        }
    }
}