using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Interactors.Input;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters;

namespace Org.Ethasia.Adventuregrid.Interactors
{
    public class CreateWorldInteractorImpl : CreateWorldInteractor
    {
        public void CreateAndRenderFirstIsland()
        {
            CoreFactory.GetInstance().InitGlobalRandomNumberGeneratorWithSeed(1726289369);

            World.CreateNewWorld();

            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();
            islandPresenter.PresentIsland(World.CurrentIsland());            
        }
    }
}