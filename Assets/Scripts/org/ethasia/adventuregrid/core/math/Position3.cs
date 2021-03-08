using System;

namespace Org.Ethasia.Adventuregrid.Core.Math
{
    public struct Position3
    {
        public float X
        {
            get;
            private set;
        }

        public float Y
        {
            get;
            private set;
        }

        public float Z
        {   
            get;
            private set;
        }

        public Position3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}