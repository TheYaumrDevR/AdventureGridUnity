using Org.Ethasia.Adventuregrid.Core.OutputInterfaces;

namespace Org.Ethasia.Adventuregrid.Core
{
    public abstract class InteractorsFactoryForCore
    {
        private static InteractorsFactoryForCore instance;

        public static void SetInstance(InteractorsFactoryForCore value)
        {
            instance = value;
        }

        public static InteractorsFactoryForCore GetInstance()
        {
            return instance;
        }

        public abstract MathInteractor CreateMathInteractorInstance();
    }
}