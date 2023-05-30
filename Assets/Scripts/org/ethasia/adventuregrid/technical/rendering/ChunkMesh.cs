using UnityEngine;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Environment.Mapgen;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering
{

    public class ChunkMesh
    {

        private GameObject chunkRoot;
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;
        private MeshCollider meshCollider;

        private VisualChunkData chunkData;

        public ChunkMesh(VisualChunkData chunkData)
        {
            this.chunkData = chunkData;

            InitMeshComponents();
            chunkRoot.name = GetUniqueChunkName();
            UpdateMeshBasedOnChunkData();
        }

        public void SetMaterial(Material chunkMaterial)
        {
            meshRenderer.material = chunkMaterial;
        }

        public void SetRootTransform(Transform rootTransform)
        {
            chunkRoot.transform.SetParent(rootTransform);
        }   

        public void SetPosition(UnityEngine.Vector3 position)
        {
            chunkRoot.transform.position = position;
        }    

        private void InitMeshComponents()
        {
            chunkRoot = new GameObject();
            meshFilter = chunkRoot.AddComponent<MeshFilter>();
            meshRenderer = chunkRoot.AddComponent<MeshRenderer>();

            if (chunkData.ChunkType == ChunkTypes.STANDARD)
            {
                meshCollider = chunkRoot.AddComponent<MeshCollider>();
            }
        } 

        private void UpdateMeshBasedOnChunkData()
        {
            Mesh mesh = new Mesh();
            UpdateGeometry(mesh);

            meshFilter.mesh = mesh;

            if (chunkData.ChunkType == ChunkTypes.STANDARD)
            {
                meshCollider.sharedMesh = mesh;
            }
        }

        private void UpdateGeometry(Mesh mesh)
        {
            UpdateGeometryVertices(mesh);
            UpdateGeometryTriangles(mesh);
            UpdateGeometryNormals(mesh);
            UpdateGeometryUvs(mesh);
        }

        private void UpdateGeometryVertices(Mesh mesh)
        {
            float[] flatVertices = chunkData.GetVertices();

            UnityEngine.Vector3[] verticesAsVectors = RenderingTypeConverter.ConvertFlatFloatArrayToVector3Array(flatVertices);
            mesh.SetVertices(verticesAsVectors);
        }

        private void UpdateGeometryTriangles(Mesh mesh)
        {
            int[] flatIndices = chunkData.GetIndices();

            mesh.SetTriangles(flatIndices, 0);            
        }

        private void UpdateGeometryNormals(Mesh mesh)
        {
            float[] flatNormals = chunkData.GetNormals();

            UnityEngine.Vector3[] normalsAsVectors = RenderingTypeConverter.ConvertFlatFloatArrayToVector3Array(flatNormals);
            mesh.SetNormals(normalsAsVectors);            
        }

        private void UpdateGeometryUvs(Mesh mesh)
        {
            float[] flatUvs = chunkData.GetUvCoordinates();

            Vector3[] uvsAsVectors = RenderingTypeConverter.ConvertFlatFloatArrayToVector3Array(flatUvs);
            mesh.SetUVs(0, uvsAsVectors);
        }          

        private string GetUniqueChunkName() 
        {
            int chunkPositionX = chunkData.GetWorldX();
            int chunkPositionY = chunkData.GetWorldY();
        
            string prefix = GetPrefixBasedOnChunkType(chunkData.ChunkType);
        
            return prefix + chunkPositionX + ", " + chunkPositionY;        
        }      

        private string GetPrefixBasedOnChunkType(ChunkTypes chunkType)
        {
            switch (chunkType)
            {
                case ChunkTypes.STANDARD:
                    return "Opaque Chunk: ";
                case ChunkTypes.FOLIAGE:
                    return "Foliage Chunk: ";
                case ChunkTypes.LIQUID:
                    return "Liquid Chunk: ";
            }

            return "";
        }                  
    }
}