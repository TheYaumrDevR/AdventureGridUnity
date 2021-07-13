using UnityEngine;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core
{

    public class RealCoreFactory : CoreFactory
    {

        public override void InitGlobalRandomNumberGeneratorWithSeed(int seed)
        {
            Random.InitState(seed);
        }

        public override IRandomNumberGenerator GetRandomNumberGeneratorInstance()
        {
            return new RandomNumberGenerator();
        }
    }
}