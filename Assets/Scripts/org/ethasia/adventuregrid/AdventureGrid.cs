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
            CoastlineGenerator islandGenerator = new CoastlineGenerator();
            Island testIsland = new Island(256);
            islandGenerator.GenerateCoastline(testIsland);
            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();

            islandPresenter.PresentIsland(testIsland);
        }
    }
}