using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.InputInterfaces;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters;

using UnityEngine;

namespace Org.Ethasia.Adventuregrid
{
    public class AdventureGrid : MonoBehaviour
    {
        void Start()
        {
            Dependencies.Inject();
            CoreFactory.GetInstance().InitGlobalRandomNumberGeneratorWithSeed(1726289369);

            World.CreateNewWorld();

            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();
            islandPresenter.PresentIsland(World.CurrentIsland());
        }
    }
}