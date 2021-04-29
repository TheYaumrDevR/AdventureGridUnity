using static Org.Ethasia.Adventuregrid.Ioadapters.Presenters.StandardIslandPresenter;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks 
{
    public class ChunkPresenter
    {
        public void PresentChunk(Island island, int chunkCoordinateX, int chunkCoordinateY)
        {
            VisualChunkData chunkRenderData = ClearRenderDataForNewChunk();

            FillRenderDataForOneChunk(island, chunkCoordinateX, chunkCoordinateY);

            RenderChunk(chunkRenderData, chunkCoordinateX, chunkCoordinateY);
        }

        private VisualChunkData ClearRenderDataForNewChunk()
        {
            return new VisualChunkData();
        }

        private void FillRenderDataForOneChunk(Island island, int chunkCoordinateX, int chunkCoordinateY) 
        {
            int amountOfBlockVerticesAdded = 0;

            for (int islandX = CHUNK_EDGE_LENGTH_IN_BLOCKS * chunkCoordinateX; islandX < CHUNK_EDGE_LENGTH_IN_BLOCKS * (chunkCoordinateX + 1); islandX++) 
            {
                for (int islandZ = CHUNK_EDGE_LENGTH_IN_BLOCKS * chunkCoordinateY; islandZ < CHUNK_EDGE_LENGTH_IN_BLOCKS * (chunkCoordinateY + 1); islandZ++) 
                {
                    for (int islandY = 0; islandY < Island.HEIGHT_IN_BLOCKS; islandY++) 
                    {
                        
                    }
                }
            }
        }

        private void RenderChunk(VisualChunkData chunkToRender, int chunkPositionX, int chunkPositionY)
        {
            ChunkRenderer chunkRenderer = TechnicalsFactory.GetInstance().GetChunkRendererInstance();

            chunkRenderer.RenderChunk(chunkToRender);
        }
    }
}