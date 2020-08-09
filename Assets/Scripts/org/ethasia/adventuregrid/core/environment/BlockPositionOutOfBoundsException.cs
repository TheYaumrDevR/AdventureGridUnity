using System;

namespace Org.Ethasia.Adventuregrid.Core.Environment
{
    public class BlockPositionOutOfBoundsException : Exception
    {
        public BlockPositionOutOfBoundsException() : base("The block position was invalid because it was out of valid bounds.") {}
    }
}