using UnityEngine;

using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters;

namespace Org.Ethasia.Adventuregrid.Technical
{
    public class OverworldScene : MonoBehaviour
    {
        void Start()
        {
            CreateTestIsland();
        }

        private void CreateTestIsland()
        {
            CoreFactory.GetInstance().InitGlobalRandomNumberGeneratorWithSeed(1726289369);

            World.CreateNewWorld();

            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();
            islandPresenter.PresentIsland(World.CurrentIsland());
        }         
    }
}