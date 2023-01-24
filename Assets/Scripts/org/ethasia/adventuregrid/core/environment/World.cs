using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Environment.Mapgen;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment 
{
    public class World
    {
        public static Island currentIsland;

        public static Island CurrentIsland() 
        {
            return currentIsland;
        }

        public static void CreateNewWorld()
        {
            CoastlineHeightMapGenerator coastlineGenerator = new CoastlineHeightMapGenerator();
            HashSet<BlockPosition> coastLine = coastlineGenerator.GenerateCoastline(512);

            TemperatePlainIslandGenerator islandGenerator = new TemperatePlainIslandGenerator();
            currentIsland = islandGenerator.GenerateIsland(512, coastLine);
        }
    }
}