using Org.Ethasia.Adventuregrid.Ioadapters;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests.Mocks 
{
    public class TechnicalsMockFactory : TechnicalsFactory
    {
        public override ChunkRenderer GetChunkRendererInstance()
        {
            return new ChunkRendererMock();
        }
    }
}