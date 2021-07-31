using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Environment.Mapgen;
using Org.Ethasia.Adventuregrid.Core.InputInterfaces;
using Org.Ethasia.Adventuregrid.Core.Math;
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

            CoastlineHeightMapGenerator coastlineGenerator = new CoastlineHeightMapGenerator();
            List<BlockPosition> coastLine = coastlineGenerator.GenerateCoastline(64);

            TemperatePlainIslandGenerator islandGenerator = new TemperatePlainIslandGenerator();
            Island testIsland = islandGenerator.GenerateIsland(64, coastLine);

            StandardIslandPresenter islandPresenter = new StandardIslandPresenter();

            islandPresenter.PresentIsland(testIsland);
        }
    }
}