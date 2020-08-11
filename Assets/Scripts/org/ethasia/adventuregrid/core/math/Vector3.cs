using System;

namespace Org.Ethasia.Adventuregrid.Core.Math
{
    public class Vector3
    {
        public static readonly Vector3 UNIT_X = new Vector3(1.0f, 0.0f, 0.0f);
        public static readonly Vector3 UNIT_Y = new Vector3(0.0f, 1.0f, 0.0f);
        public static readonly Vector3 UNIT_Z = new Vector3(0.0f, 0.0f, 1.0f);

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

        public Vector3 Set(float x, float y, float z) 
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

        public Vector3(float x, float y, float z) 
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float GetSquaredLength() 
        {
            return x * x + y * y + z * z;
        } 

        public Vector3 Scale(float scalar) 
        {
            x *= scalar;
            y *= scalar;
            z *= scalar;
        
            return this;
        }

        public Vector3 ScaleImmutable(float scalar) 
        {
            float scaledX = x * scalar;
            float scaledY  = y * scalar;
            float scaledZ  = z * scalar;
        
            return new Vector3(scaledX, scaledY, scaledZ);
        }   

        public Vector3 Normalize() 
        {
            float squaredLength = GetSquaredLength();
            if (0.0f == squaredLength || 1.0f == squaredLength) 
            {
                return this;
            }
        
            return Scale(1.0f / (float)System.Math.Sqrt(squaredLength));
        }

        public Vector3 Add(Vector3 other) 
        {
            x += other.x;
            y += other.y;
            z += other.z;
        
            return this;
        } 

        public Vector3 AddImmutable(Vector3 other) 
        {
            float resultX = x + other.x;
            float resultY = y + other.y;
            float resultZ = z + other.z;
        
            return new Vector3(resultX, resultY, resultZ);
        }

        public void AddImmutableBufferResult(Vector3 other) 
        {
            bufferedResultX = x + other.x;
            bufferedResultY = y + other.y;
            bufferedResultZ = z + other.z;
        }             

        public Vector3 Subtract(Vector3 other) 
        {
            x -= other.x;
            y -= other.y;
            z -= other.z;
        
            return this;
        } 

        public Vector3 SubtractImmutable(Vector3 other) 
        {
            float resultX = x - other.x;
            float resultY = y - other.y;
            float resultZ = z - other.z;
        
            return new Vector3(resultX, resultY, resultZ);
        }     

        public float Dot(Vector3 other) 
        {
            return x * other.x + y * other.y + z * other.z;
        }    

        public Vector3 Cross(Vector3 other) 
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