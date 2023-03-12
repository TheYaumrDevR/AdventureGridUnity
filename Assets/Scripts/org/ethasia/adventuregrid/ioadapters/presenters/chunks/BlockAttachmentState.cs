namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public struct BlockAttachmentState
    {
        public bool IsAttachedToLeftNeighbor
        {
            get;
            set;
        }

        public bool IsAttachedToFrontNeighbor
        {
            get;
            set;
        }  

        public bool IsAttachedToRightNeighbor
        {
            get;
            set;
        }   

        public bool IsAttachedToBackNeighbor
        {
            get;
            set;
        }       

        public bool IsAttachedToTopNeighbor
        {
            get;
            set;
        }   

        public bool IsAttachedToBottomNeighbor
        {
            get;
            set;
        }                         
    }
}