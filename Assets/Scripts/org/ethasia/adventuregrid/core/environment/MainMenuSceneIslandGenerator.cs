namespace Org.Ethasia.Adventuregrid.Core.Environment
{

    public class MainMenuSceneIslandGenerator
    {

        public Island CreateIslandForMainMenuScene()
        {
            Island result = new Island(20);

            Block rockBlock = RockBlock.GetInstance();
            Block earthBlock = EarthBlock.GetInstance();
            Block grassBlock = GrassyEarthBlock.GetInstance();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (k == 0)
                        {
                            result.PlaceBlockAt(rockBlock, i, k, j);
                        }
                        else if (k == 1)
                        {
                            result.PlaceBlockAt(earthBlock, i, k, j);
                        }
                        else 
                        {
                            result.PlaceBlockAt(grassBlock, i, k, j);
                        }
                    }
                }
            }

            return result;
        }
    }
}