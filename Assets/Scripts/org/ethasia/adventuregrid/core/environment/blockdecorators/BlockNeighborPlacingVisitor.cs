namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators
{ 
    public class BlockNeighborPlacingVisitor : BlockDecoratorVisitor
    {
        private static BlockNeighborPlacingVisitor instance;

        private NeighborAttachingBlockDecorator stateToUpdate;

        public static BlockNeighborPlacingVisitor GetInstance()
        {
            if (null == instance)
            {
                instance = new BlockNeighborPlacingVisitor();
            }
            
            instance.stateToUpdate = null;
            return instance;
        }

        private BlockNeighborPlacingVisitor() {}        

        public void Accept(RotationDataBlockDecorator visited) 
        {

        }

        public void Accept(NeighborAttachingBlockDecorator visited)
        {
            stateToUpdate = visited;
        }   

        public void BlockWasPlacedToLeft(Block leftNeighbor)
        {
            if (null != stateToUpdate)
            {
                stateToUpdate.BlockWasPlacedToLeft(leftNeighbor);
            }
        }

        public void BlockWasPlacedToRight(Block rightNeighbor)
        {
            if (null != stateToUpdate)
            {
                stateToUpdate.BlockWasPlacedToRight(rightNeighbor);
            }
        }    

        public void BlockWasPlacedToFront(Block frontNeighbor)
        {
            if (null != stateToUpdate)
            {
                stateToUpdate.BlockWasPlacedToFront(frontNeighbor);
            }
        }           

        public void BlockWasPlacedToBack(Block backNeighbor)
        {
            if (null != stateToUpdate)
            {
                stateToUpdate.BlockWasPlacedToBack(backNeighbor);
            }
        }         

        public void BlockWasPlacedToTop(Block topNeighbor)
        {
            if (null != stateToUpdate)
            {
                stateToUpdate.BlockWasPlacedToTop(topNeighbor);
            }
        }  

        public void BlockWasPlacedToBottom(Block bottomNeighbor)
        {
            if (null != stateToUpdate)
            {
                stateToUpdate.BlockWasPlacedToBottom(bottomNeighbor);
            }
        }      
    }
}