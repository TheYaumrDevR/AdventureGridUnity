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

        public override bool Equals(object other)
        {
            if (other is BlockPosition) 
            {
                BlockPosition otherBlockPosition = (BlockPosition)other;

                return otherBlockPosition.X == X
                    && otherBlockPosition.Y == Y
                    && otherBlockPosition.Z == Z;
            }

            return false;
        }      

        public override int GetHashCode()
        {
            return X + 1024 * Y + 1000000 * Z;
        }        
    }
}