namespace Org.Ethasia.Adventuregrid.Interactors
{
    public class MainMenuSceneInteractor
    {
        public void GenerateMainMenuSceneAndEnterMainMenu()
        {
            MainMenuSceneIslandGenerator sceneMapGenerator = new MainMenuSceneIslandGenerator();
            Island sceneMap = sceneMapGenerator.CreateIslandForMainMenuScene();
            // TODO: Render scene map
        }
    }
}