using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

using Org.Ethasia.Adventuregrid.Core.Environment;
using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering
{

    public class ChunkMesh : MonoBehaviour
    {

        public MeshRenderer meshRenderer;
        public MeshFilter meshFilter;

        void Start()
        {
            Mesh mesh = new Mesh();

            Block testBlockToRender = RockBlock.GetInstance();
            StandardBlockVisualsBuilder testBlockBuilder = new StandardBlockVisualsBuilder();

            testBlockBuilder.SetBlockToCreateDataFrom(testBlockToRender)
                .SetPositionOfBlockInChunk(new BlockPosition(0, 0, 0))
                .SetFrontFaceOfBlockIsHidden(false)
                .SetRightFaceOfBlockIsHidden(false)
                .SetBackFaceOfBlockIsHidden(false)
                .SetLeftFaceOfBlockIsHidden(false)
                .SetBottomFaceOfBlockIsHidden(false)
                .SetTopFaceOfBlockIsHidden(false)
                .SetIndexBufferOffsetInChunk(0)
                .Build();

            UnityEngine.Vector3[] meshVertices = RenderingTypeConverter.ConvertFlatFloatArrayToVector3Array(testBlockBuilder.GetShapePositions());
            UnityEngine.Vector3[] meshNormals = RenderingTypeConverter.ConvertFlatFloatArrayToVector3Array(testBlockBuilder.GetShapeNormals());
            Vector2[] meshUvs = RenderingTypeConverter.ConvertFlatFloatArrayToVector2Array(testBlockBuilder.GetShapeUvCoordinates());

            mesh.SetVertices(meshVertices);
            mesh.SetTriangles(testBlockBuilder.GetShapeIndices(), 0);
            mesh.SetNormals(meshNormals);
            mesh.SetUVs(0, meshUvs);

            meshFilter.mesh = mesh;
        }
    }
}