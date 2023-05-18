using Org.Ethasia.Adventuregrid.Core.OutputInterfaces;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Output;

namespace Org.Ethasia.Adventuregrid.Interactors
{
    public class MathInteractorImpl : MathInteractor
    {
        private MathGateway mathGateway;

        public MathInteractorImpl()
        {
            mathGateway = IoAdaptersFactoryForInteractors.GetInstance().CreateMathGateway();
        }

        public int CeilToInt(float f)
        {
            return mathGateway.CeilToInt(f);
        }

        public float Pow(float number, float exponent)
        {
            return mathGateway.Pow(number, exponent);
        }
    }
}