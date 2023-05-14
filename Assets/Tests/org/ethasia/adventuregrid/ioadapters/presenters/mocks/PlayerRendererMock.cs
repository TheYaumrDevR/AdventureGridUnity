using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Mocks
{
    public class PlayerRendererMock : PlayerRenderer
    {
        private static BlockPosition? lastPlayerPosition;

        public static BlockPosition? GetLastPlayerPosition()
        {
            return lastPlayerPosition;
        }

        public static void ResetMock()
        {
            lastPlayerPosition = null;
        }

        public void RenderPlayerAt(BlockPosition renderPosition)
        {
            lastPlayerPosition = renderPosition;
        }
    }
}