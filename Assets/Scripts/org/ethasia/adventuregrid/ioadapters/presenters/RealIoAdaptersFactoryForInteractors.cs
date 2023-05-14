using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Output;

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
    }
}