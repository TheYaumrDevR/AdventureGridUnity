namespace Org.Ethasia.Adventuregrid.Core.Math
{
    
    public interface IRandomNumberGenerator
    {

        int GenerateIntegerBetweenAnd(int min, int max);
        int GenerateRandomPositiveInteger(int max);
    }
}