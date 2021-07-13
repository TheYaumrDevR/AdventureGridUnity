using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core
{

    public abstract class CoreFactory
    {

        private static CoreFactory instance;

        public static void SetInstance(CoreFactory value)
        {
            instance = value;
        }

        public static CoreFactory GetInstance()
        {
            return instance;
        }

        public abstract void InitGlobalRandomNumberGeneratorWithSeed(int seed);
        public abstract IRandomNumberGenerator GetRandomNumberGeneratorInstance();
    }
}