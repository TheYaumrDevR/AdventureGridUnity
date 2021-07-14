using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Core.Math.Mocks;

namespace Org.Ethasia.Adventuregrid.Core.Tests
{
    public class MockCoreFactory : CoreFactory
    {

        RandomNumberGeneratorMock randomNumberGeneratorMock;

        public MockCoreFactory(RandomNumberGeneratorMock rngMock)
        {
            randomNumberGeneratorMock = rngMock;
        }

        public override void InitGlobalRandomNumberGeneratorWithSeed(int seed)
        {
        }

        public override IRandomNumberGenerator GetRandomNumberGeneratorInstance()
        {
            return randomNumberGeneratorMock;
        }
    }
}