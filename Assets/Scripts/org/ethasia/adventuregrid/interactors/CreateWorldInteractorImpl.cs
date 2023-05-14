using System;

using Org.Ethasia.Adventuregrid.Core;
using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Interactors.Factories;
using Org.Ethasia.Adventuregrid.Interactors.Input;
using Org.Ethasia.Adventuregrid.Interactors.Output;

namespace Org.Ethasia.Adventuregrid.Interactors
{
    public class CreateWorldInteractorImpl : CreateWorldInteractor
    {
        public void CreateAndRenderFirstIsland()
        {
            CoreFactory.GetInstance().InitGlobalRandomNumberGeneratorWithSeed(GenerateRandomSeed());

            World.CreateNewWorld();

            IslandPresenter islandPresenter = IoAdaptersFactoryForInteractors.GetInstance().CreateIslandPresenter();
            PlayerCharacterPresenter playerCharacterPresenter = IoAdaptersFactoryForInteractors.GetInstance().CreatePlayerCharacterPresenter();
            
            islandPresenter.PresentIsland(World.CurrentIsland());
            playerCharacterPresenter.PresentPlayerCharacter(World.CurrentIsland().PlayerSpawnPosition);        
        }

        private int GenerateRandomSeed()
        {
            long currentDateTimeTicks = DateTime.Now.Ticks;
            int lowerTicksBits = (int)(currentDateTimeTicks & 0xffffffffL);
            int upperTicksBits = (int)(currentDateTimeTicks >> 32);

            System.Random rng = new System.Random(lowerTicksBits | upperTicksBits);

            return rng.Next();
        }
    }
}