using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.Mocks
{
    public class ChunkRendererMock : ChunkRenderer
    {
        private static readonly List<VisualChunkData> renderedChunkData;
        private static VisualChunkData lastRenderChunkCallData;

        static ChunkRendererMock()
        {
            renderedChunkData = new List<VisualChunkData>();
        }

        public static List<VisualChunkData> GetRenderedChunkData()
        {
            return renderedChunkData;
        }

        public static VisualChunkData GetLastRenderChunkCallData()
        {
            return lastRenderChunkCallData;
        }

        public static void ResetMock()
        {
            lastRenderChunkCallData = null;
            renderedChunkData.Clear();
        }

        public void RenderChunk(VisualChunkData chunkData)
        {
            lastRenderChunkCallData = chunkData;
            renderedChunkData.Add(chunkData);
        }
    }
}