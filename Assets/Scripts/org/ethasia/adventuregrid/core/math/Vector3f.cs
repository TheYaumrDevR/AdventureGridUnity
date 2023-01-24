using System;

namespace Org.Ethasia.Adventuregrid.Core.Math
{
    public class Vector3f
    {
        public static readonly Vector3f UNIT_X = new Vector3f(1.0f, 0.0f, 0.0f);
        public static readonly Vector3f UNIT_Y = new Vector3f(0.0f, 1.0f, 0.0f);
        public static readonly Vector3f UNIT_Z = new Vector3f(0.0f, 0.0f, 1.0f);

        private float x, y, z;

        public float GetX() 
        {
            return x;
        }
    
        public float GetY() 
        {
            return y;
        } 
    
        public float GetZ() 
        {
            return z;
        }     

        public Vector3f Set(float x, float y, float z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        
            return this;
        }     

        private float bufferedResultX, bufferedResultY, bufferedResultZ;     

        public float GetBufferedResultX() 
        {
            return bufferedResultX;
        }

        public float GetBufferedResultY() 
        {
            return bufferedResultY;
        }   
    
        public float GetBufferedResultZ() 
        {
            return bufferedResultZ;
        }         

        public Vector3f(float x, float y, float z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float GetSquaredLength() 
        {
            return x * x + y * y + z * z;
        } 

        public Vector3f Scale(float scalar) 
        {
            x *= scalar;
            y *= scalar;
            z *= scalar;
        
            return this;
        }

        public Vector3f ScaleImmutable(float scalar) 
        {
            float scaledX = x * scalar;
            float scaledY  = y * scalar;
            float scaledZ  = z * scalar;
        
            return new Vector3f(scaledX, scaledY, scaledZ);
        }   

        public Vector3f Normalize() 
        {
            float squaredLength = GetSquaredLength();
            if (0.0f == squaredLength || 1.0f == squaredLength) 
            {
                return this;
            }
        
            return Scale(1.0f / (float)System.Math.Sqrt(squaredLength));
        }

        public Vector3f Add(Vector3f other) 
        {
            x += other.x;
            y += other.y;
            z += other.z;
        
            return this;
        } 

        public Vector3f AddImmutable(Vector3f other) 
        {
            float resultX = x + other.x;
            float resultY = y + other.y;
            float resultZ = z + other.z;
        
            return new Vector3f(resultX, resultY, resultZ);
        }

        public void AddImmutableBufferResult(Vector3f other) 
        {
            bufferedResultX = x + other.x;
            bufferedResultY = y + other.y;
            bufferedResultZ = z + other.z;
        }   

        public void AddImmutableBufferResult(Position3 toAdd)
        {
            bufferedResultX = x + toAdd.X;
            bufferedResultY = y + toAdd.Y;
            bufferedResultZ = z + toAdd.Z;            
        }          

        public Vector3f Subtract(Vector3f other) 
        {
            x -= other.x;
            y -= other.y;
            z -= other.z;
        
            return this;
        } 

        public Vector3f SubtractImmutable(Vector3f other) 
        {
            float resultX = x - other.x;
            float resultY = y - other.y;
            float resultZ = z - other.z;
        
            return new Vector3f(resultX, resultY, resultZ);
        }     

        public float Dot(Vector3f other) 
        {
            return x * other.x + y * other.y + z * other.z;
        }    

        public Vector3f Cross(Vector3f other) 
        {
            float newX = y * other.z - z * other.y;
            float newY = z * other.x - x * other.z;
            float newZ = x * other.y - y * other.x;
        
            x = newX;
            y = newY;
            z = newZ;
        
            return this;
        }                                                              
    }
}