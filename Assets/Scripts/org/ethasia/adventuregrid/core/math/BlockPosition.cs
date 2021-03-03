namespace Org.Ethasia.Adventuregrid.Core.Math
{
    public struct BlockPosition
    {
        public int X
        {
            get;
            private set;
        }

        public int Y 
        {
            get;
            private set;
        }

        public int Z
        {
            get;
            private set;
        }

        public BlockPosition(int x, int y, int z) 
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}