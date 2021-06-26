using UnityEngine;

using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering
{
    public class ChunkRendererImpl : MonoBehaviour, ChunkRenderer
    {

        public Material opaqueChunkMaterial; 

        public void RenderChunk(VisualChunkData chunkData)
        {
            CreateChunkMesh(chunkData);
        }

        private ChunkMesh CreateChunkMesh(VisualChunkData chunkData)
        {
            ChunkMesh result = new ChunkMesh(chunkData);
            result.SetMaterial(opaqueChunkMaterial);
            result.SetRootTransform(transform);

            return result;
        }      
    }
}
