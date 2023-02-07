using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Environment.Mapgen;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Input;
using Org.Ethasia.Adventuregrid.Interactors.Output;

namespace Org.Ethasia.Adventuregrid.Interactors
{
    public class SetupMainMenuInteractorImpl : SetupMainMenuInteractor
    {
        public void GenerateMainMenuSceneAndEnterMainMenu()
        {
            CoreFactory.GetInstance().InitGlobalRandomNumberGeneratorWithSeed(487500828);

            CoastlineHeightMapGenerator coastlineGenerator = new CoastlineHeightMapGenerator();
            HashSet<BlockPosition> coastLine = coastlineGenerator.GenerateCoastline(64);

            MainMenuIslandGenerator islandGenerator = new MainMenuIslandGenerator();
            Island generatedIsland = islandGenerator.GenerateIsland(64, coastLine);

            IslandPresenter islandPresenter = IoAdaptersFactoryForInteractors.GetInstance().CreateIslandPresenter();
            islandPresenter.PresentIsland(generatedIsland);
        }
    }
}