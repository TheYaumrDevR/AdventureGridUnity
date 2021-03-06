using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Environment.Mapgen;
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
            CoreFactory.GetInstance().InitGlobalRandomNumberGeneratorWithSeed(83457547);
            CoastlineGenerator islandGenerator = new CoastlineGenerator();
            Island testIsland = new Island(1024);
            islandGenerator.GenerateCoastline(testIsland);
            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();

            islandPresenter.PresentIsland(testIsland);
        }
    }
}