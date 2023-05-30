namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class VisualChunkData
    {
        #region Fields

        private int worldX;
        private int worldY;

        private float[][] verticesOfBlocks;
        private int[][] indicesOfBlocks;
        private float[][] normalsOfBlocks;
        private float[][] uvCoordinatesOfBlocks;

        private int currentVertexAmount;
        private int currentIndexAmount;
        private int currentNormalsAmount;
        private int currentUvAmount;

        private int numberOfTimesVerticesAdded;
        private int numberOfTimesIndicesAdded;
        private int numberOfTimesNormalsAdded;
        private int numberOfTimesUvAdded;

        private float[] allVerticesFlattened;
        private int[] allIndicesFlattened;
        private float[] allNormalsFlattened;
        private float[] allUvCoordinatesFlattened;

        #endregion

        #region Methods

        public ChunkTypes ChunkType
        {
            get;
            set;
        }

        public void SetWorldPosition(int x, int y)
        {   
            worldX = x;
            worldY = y;
        }

        public int GetWorldX() 
        {
            return worldX;
        }

        public int GetWorldY()
        {
            return worldY;
        }

        public float[] GetVertices() 
        {
            return allVerticesFlattened;
        }

        public int[] GetIndices() 
        {
            return allIndicesFlattened;
        }

        public float[] GetNormals()
        {
            return allNormalsFlattened;
        }

        public float[] GetUvCoordinates()
        {
            return allUvCoordinatesFlattened;
        }

        public void SetUpWithNumberOfBlocksInChunk(int numberOfBlocksInChunk) 
        {
            verticesOfBlocks = new float[numberOfBlocksInChunk][];
            indicesOfBlocks = new int[numberOfBlocksInChunk][];
            normalsOfBlocks = new float[numberOfBlocksInChunk][];
            uvCoordinatesOfBlocks = new float[numberOfBlocksInChunk][];
        }

        public void AddVerticesToTemporaryBuffer(float[] vertices) 
        {
            verticesOfBlocks[numberOfTimesVerticesAdded] = vertices;
            currentVertexAmount += vertices.Length;
            numberOfTimesVerticesAdded++;        
        }   

        public void AddIndicesToTemporaryBuffer(int[] indices) 
        {
            indicesOfBlocks[numberOfTimesIndicesAdded] = indices;
            currentIndexAmount += indices.Length;   
            numberOfTimesIndicesAdded++;
        } 

        public void AddNormalsToTemporaryBuffer(float[] normals) 
        {
            normalsOfBlocks[numberOfTimesNormalsAdded] = normals;
            currentNormalsAmount += normals.Length;
            numberOfTimesNormalsAdded++;        
        }  

        public void AddUvCoordinatesToTemporaryBuffer(float[] uvCoordinates) 
        {
            uvCoordinatesOfBlocks[numberOfTimesUvAdded] = uvCoordinates;
            currentUvAmount += uvCoordinates.Length;
            numberOfTimesUvAdded++;        
        }   

        public void BuildChunkData() 
        {
            FlattenVertices();
            FlattenIndices();
            FlattenNormals();
            FlattenUvs();
        }                                

        #endregion

        #region Helper Methods

        private void FlattenVertices() 
        {
            allVerticesFlattened = new float[currentVertexAmount];
            int k = 0;  
        
            for (int i = 0; i < verticesOfBlocks.Length; i++) 
            {
                for (int j = 0; j < verticesOfBlocks[i].Length; j++) 
                {
                    allVerticesFlattened[k] = verticesOfBlocks[i][j];
                    k++;
                }
            }        
        }      

        private void FlattenIndices() 
        {
            allIndicesFlattened = new int[currentIndexAmount];
            int k = 0;  
        
            for (int i = 0; i < indicesOfBlocks.Length; i++) 
            {
                for (int j = 0; j < indicesOfBlocks[i].Length; j++) 
                {
                    allIndicesFlattened[k] = indicesOfBlocks[i][j];
                    k++;
                }
            }        
        }  

        private void FlattenNormals() 
        {
            allNormalsFlattened = new float[currentNormalsAmount];
            int k = 0;  
        
            for (int i = 0; i < normalsOfBlocks.Length; i++) 
            {
                for (int j = 0; j < normalsOfBlocks[i].Length; j++) 
                {
                    allNormalsFlattened[k] = normalsOfBlocks[i][j];
                    k++;
                }
            }           
        }

        private void FlattenUvs() 
        {
            allUvCoordinatesFlattened = new float[currentUvAmount];
            int k = 0;  
        
            for (int i = 0; i < uvCoordinatesOfBlocks.Length; i++) 
            {
                for (int j = 0; j < uvCoordinatesOfBlocks[i].Length; j++) 
                {
                    allUvCoordinatesFlattened[k] = uvCoordinatesOfBlocks[i][j];
                    k++;
                }
            }        
        }                          

        #endregion
    }
}