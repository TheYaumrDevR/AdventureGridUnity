using Org.Ethasia.Adventuregrid.Ioadapters;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Mocks
{
    public class TechnicalsMockFactory : TechnicalsFactory
    {
        public override ChunkRenderer GetChunkRendererInstance()
        {
            return new ChunkRendererMock();
        }

        public override PlayerRenderer GetPlayerRendererInstance()
        {
            return new PlayerRendererMock();
        }
    }
}