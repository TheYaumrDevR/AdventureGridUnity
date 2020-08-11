namespace Org.Ethasia.Adventuregrid.Core.Math
{
    public class FastMath
    {
        public static int Floor(double x) 
        {
            int xCast = (int)x;
            return x < xCast ? xCast - 1 : xCast;            
        }
    }
}