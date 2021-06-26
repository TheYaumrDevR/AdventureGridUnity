using Org.Ethasia.Adventuregrid.Ioadapters;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;
using Org.Ethasia.Adventuregrid.Technical.Rendering;

namespace Org.Ethasia.Adventuregrid.Technical
{
    public class RealTechnicalsFactory : TechnicalsFactory
    {
        private ChunkRenderer chunkRenderer;

        public override ChunkRenderer GetChunkRendererInstance() {
            if (null == chunkRenderer)
            {
                chunkRenderer = ChunkRendererImpl.GetInstance();
            }

            return chunkRenderer;
        }
    }
}