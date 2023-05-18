using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Output;
using Org.Ethasia.Adventuregrid.Ioadapters.Gateways;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters 
{
    public class RealIoAdaptersFactoryForInteractors : IoAdaptersFactoryForInteractors
    {
        public override IslandPresenter CreateIslandPresenter()
        {
            return new StandardIslandPresenter();
        }

        public override PlayerCharacterPresenter CreatePlayerCharacterPresenter()
        {
            return new StandardPlayerCharacterPresenter();
        }        

        public override MathGateway CreateMathGateway()
        {
            return new MathGatewayImpl();
        }
    }
}