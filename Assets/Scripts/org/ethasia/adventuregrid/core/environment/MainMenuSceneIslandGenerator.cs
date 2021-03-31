using Org.Ethasia.Adventuregrid.Core.Math;

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
                        BlockPosition blockPosition = new BlockPosition(i, k, j);

                        if (k == 0)
                        {
                            result.PlaceBlockAt(rockBlock, blockPosition);
                        }
                        else if (k == 1)
                        {
                            result.PlaceBlockAt(earthBlock, blockPosition);
                        }
                        else 
                        {
                            result.PlaceBlockAt(grassBlock, blockPosition);
                        }
                    }
                }
            }

            return result;
        }
    }
}