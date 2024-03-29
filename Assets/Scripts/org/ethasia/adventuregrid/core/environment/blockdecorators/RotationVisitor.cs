namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{
    public class RotationVisitor : BlockDecoratorVisitor
    {
        private static RotationVisitor instance;

        private RotationDataBlockDecorator visited;

        public static RotationVisitor GetInstance()
        {
            if (null == instance)
            {
                instance = new RotationVisitor();
            }
            
            instance.visited = null;
            return instance;
        }        

        private RotationVisitor()
        {

        }        

        public void Accept(RotationDataBlockDecorator visited) 
        {
            this.visited = visited;
        }        

        public void Accept(NeighborAttachingBlockDecorator visited)
        {
            
        }

        public void RotatePositiveAroundXAxis()
        {
            if (null != visited)
            {
                visited.RotatePositiveAroundXAxis();
            }
        }   

        public void RotateNegativeAroundXAxis()
        {
            if (null != visited)
            {
                visited.RotateNegativeAroundXAxis();
            }
        } 

        public void RotatePositiveAroundYAxis()
        {
            if (null != visited)
            {
                visited.RotatePositiveAroundYAxis();
            }
        } 

        public void RotateNegativeAroundYAxis()
        {
            if (null != visited)
            {
                visited.RotateNegativeAroundYAxis();
            }
        } 

        public void RotatePositiveAroundZAxis()
        {
            if (null != visited)
            {
                visited.RotatePositiveAroundZAxis();
            }
        } 

        public void RotateNegativeAroundZAxis()
        {
            if (null != visited)
            {
                visited.RotateNegativeAroundZAxis();
            }
        }                                                      
    }
}