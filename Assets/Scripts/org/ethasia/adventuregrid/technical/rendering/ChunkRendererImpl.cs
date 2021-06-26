using UnityEngine;

using Org.Ethasia.Adventuregrid.Ioadapters.Presenters;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Interfaces.Technical;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering
{
    public class ChunkRendererImpl : MonoBehaviour, ChunkRenderer
    {

        private static ChunkRendererImpl instance;
        public Material opaqueChunkMaterial; 

        void Awake()
        {
            instance = this;
        }

        public static ChunkRenderer GetInstance()
        {
            return instance;
        }

        public void RenderChunk(VisualChunkData chunkData)
        {
            CreateChunkMesh(chunkData);
        }

        private ChunkMesh CreateChunkMesh(VisualChunkData chunkData)
        {
            ChunkMesh result = new ChunkMesh(chunkData);
            result.SetMaterial(opaqueChunkMaterial);
            result.SetRootTransform(transform);

            Vector3 chunkPosition = new Vector3(chunkData.GetWorldX() * StandardIslandPresenter.CHUNK_EDGE_LENGTH_IN_BLOCKS * 0.5f, 0, chunkData.GetWorldY() * StandardIslandPresenter.CHUNK_EDGE_LENGTH_IN_BLOCKS * 0.5f);
            result.SetPosition(chunkPosition);

            return result;
        }      
    }
}
