using Org.Ethasia.Adventuregrid.Core.Environment;

namespace Org.Ethasia.Adventuregrid.Core.InputInterfaces
{
    public interface IslandGenerator
    {
        Island GenerateIsland(int edgeLength);
    }
}