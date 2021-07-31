using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.InputInterfaces
{
    public interface IslandGenerator
    {
        Island GenerateIsland(int edgeLength, HashSet<BlockPosition> coastlineHeightMap);
    }
}