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
            IslandGenerator islandGenerator = new TemperatePlainIslandGenerator();
            Island testIsland = islandGenerator.GenerateIsland(128);
            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();

            islandPresenter.PresentIsland(testIsland);
        }
    }
}