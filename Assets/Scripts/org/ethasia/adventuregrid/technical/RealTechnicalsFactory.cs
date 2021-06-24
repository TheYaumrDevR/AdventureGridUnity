using Org.Ethasia.Adventuregrid.Ioadapters;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Technical
{
    public class RealTechnicalsFactory : TechnicalsFactory
    {
        private ChunkRenderer chunkRenderer;

        public override ChunkRenderer GetChunkRendererInstance() {
            return null;
        }
    }
}