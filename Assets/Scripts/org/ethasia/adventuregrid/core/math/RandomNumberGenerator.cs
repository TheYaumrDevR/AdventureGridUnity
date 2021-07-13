using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Core.Math
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {

        public int GenerateIntegerBetweenAnd(int min, int max)
        {
            float lowerBound = min + 0.0f;
            float upperBound = max + 1.0f;

            float randomNumber = Random.Range(lowerBound, upperBound);

            if (max == randomNumber)
            {
                return GenerateIntegerBetweenAnd(min, max);
            }            

            return FastMath.Floor(randomNumber);
        }

        public int GenerateRandomPositiveInteger(int max)
        {
            float lowerBound = 0.0f;
            float upperBound = max + 1.0f;

            float randomNumber = Random.Range(lowerBound, upperBound);

            if (max == randomNumber)
            {
                return GenerateRandomPositiveInteger(max);
            }

            return FastMath.Floor(randomNumber);
        }
    }
}
