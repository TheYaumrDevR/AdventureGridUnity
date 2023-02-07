using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Interactors.Output;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks ;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters 
{
    public class StandardIslandPresenter : IslandPresenter
    {
        public static readonly int CHUNK_EDGE_LENGTH_IN_BLOCKS = 16;

        private readonly ChunkPresenter chunkPresenter;     

        public StandardIslandPresenter()
        {
            chunkPresenter = new ChunkPresenter();
        }

        public void PresentIsland(Island island)
        {
            int chunkCountPerIslandEdge = CalculateChunkCountPerIslandEdge(island);
        
            for (int i = 0; i < chunkCountPerIslandEdge; i++) 
            {
                for (int j = 0; j < chunkCountPerIslandEdge; j++) 
                {
                    chunkPresenter.PresentChunk(island, i, j);
                }            
            }
        }

        private int CalculateChunkCountPerIslandEdge(Island island) 
        {
            int result = 0;
            for (int i = 0; i * CHUNK_EDGE_LENGTH_IN_BLOCKS < island.GetXzDimension(); i++) 
            {
                result++;
            }  
        
            return result;
        }        
    }
}