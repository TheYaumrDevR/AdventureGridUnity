using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Math.Mocks
{

    public class RandomNumberGeneratorMock : IRandomNumberGenerator
    {

        private int[] toBeGeneratedRandomNumbers;
        private int randomNumberIndex;

        public RandomNumberGeneratorMock(int[] randomNumbersToGenerate)
        {
            toBeGeneratedRandomNumbers = randomNumbersToGenerate;
        }

        public int GenerateIntegerBetweenAnd(int min, int max)
        {
            return GetNextGeneratedRandomNumber();
        }

        public int GenerateRandomPositiveInteger(int max)
        {
            return GetNextGeneratedRandomNumber();
        }

        private int GetNextGeneratedRandomNumber()
        {
            if (randomNumberIndex < toBeGeneratedRandomNumbers.Length)
            {
                int result = toBeGeneratedRandomNumbers[randomNumberIndex];
                randomNumberIndex++;

                return result;
            }

            return -1;
        }
    }
}