using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.OutputInterfaces;

namespace Org.Ethasia.Adventuregrid.Interactors.Factories
{
    public class RealInteractorsFactoryForCore : InteractorsFactoryForCore
    {
        public override MathInteractor CreateMathInteractorInstance()
        {
            return new MathInteractorImpl();
        }
    }
}