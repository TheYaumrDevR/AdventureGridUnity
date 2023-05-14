using Org.Ethasia.Adventuregrid.Core.Math;

using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical
{
    public interface PlayerRenderer
    {
        void RenderPlayerAt(BlockPosition renderPosition);
    }
}