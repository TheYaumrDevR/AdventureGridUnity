using NUnit.Framework;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks.ChunkPresentingTests
{
    public class VisualChunkDataTests
    {
        [UnityTest]
        public IEnumerator WorldPositionCanBeSet() 
        {
            VisualChunkData testCandidate = new VisualChunkData();

            testCandidate.SetWorldPosition(5, 9);

            yield return null;

            Assert.That(testCandidate.GetWorldX(), Is.EqualTo(5));
            Assert.That(testCandidate.GetWorldY(), Is.EqualTo(9));         
        }

        [UnityTest]
        public IEnumerator FlattenedVerticesAreCalculatedFromTemporaryBuffer() 
        {
            VisualChunkData testCandidate = new VisualChunkData();
        
            float[] vertices = { 0.2f, 0.3f, 0.4f, 0.3f, 0.7f, 0.1f };
            float[] secondVertices = { 0.3f, 0.4f, 0.5f, 0.6f, 0.8f, 0.3f };
        
            testCandidate.SetUpWithNumberOfBlocksInChunk(2);
            testCandidate.AddVerticesToTemporaryBuffer(vertices);
            testCandidate.AddVerticesToTemporaryBuffer(secondVertices);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);  
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);      
        
            testCandidate.BuildChunkData();
            float[] result = testCandidate.GetVertices();
        
            yield return null;

            Assert.That(result.Length, Is.EqualTo(12));
            Assert.That(result[0], Is.EqualTo(0.2f));
            Assert.That(result[1], Is.EqualTo(0.3f));
            Assert.That(result[2], Is.EqualTo(0.4f));
            Assert.That(result[3], Is.EqualTo(0.3f));
            Assert.That(result[4], Is.EqualTo(0.7f));
            Assert.That(result[5], Is.EqualTo(0.1f));
            Assert.That(result[6], Is.EqualTo(0.3f));
            Assert.That(result[7], Is.EqualTo(0.4f));    
            Assert.That(result[8], Is.EqualTo(0.5f));
            Assert.That(result[9], Is.EqualTo(0.6f));
            Assert.That(result[10], Is.EqualTo(0.8f));
            Assert.That(result[11], Is.EqualTo(0.3f));
        } 

        [UnityTest]
        public IEnumerator FlattenedIndicesAreCalculatedFromTemporaryBuffer() 
        {
            VisualChunkData testCandidate = new VisualChunkData();
        
            int[] indices = { 2, 4 };
            int[] secondIndices = { 5, 7 };
            int[] thirdIndices = { 9, 8 };
        
            testCandidate.SetUpWithNumberOfBlocksInChunk(3);
            testCandidate.AddIndicesToTemporaryBuffer(indices);
            testCandidate.AddIndicesToTemporaryBuffer(secondIndices);
            testCandidate.AddIndicesToTemporaryBuffer(thirdIndices);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]); 
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);        
        
            testCandidate.BuildChunkData();
            int[] result = testCandidate.GetIndices();

            yield return null;

            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EqualTo(2));
            Assert.That(result[1], Is.EqualTo(4));
            Assert.That(result[2], Is.EqualTo(5));
            Assert.That(result[3], Is.EqualTo(7));
            Assert.That(result[4], Is.EqualTo(9));
            Assert.That(result[5], Is.EqualTo(8));              
        }

        [UnityTest]
        public IEnumerator FlattenedNormalsAreCalculatedFromTemporaryBuffer() 
        {
            VisualChunkData testCandidate = new VisualChunkData();
        
            float[] normals = { 1.4f, 2.3f };
            float[] secondNormals = { 5.4f, 7.1f };
            float[] thirdNormals = { 0.4f, 1.5f };     
        
            testCandidate.SetUpWithNumberOfBlocksInChunk(3);
            testCandidate.AddNormalsToTemporaryBuffer(normals);
            testCandidate.AddNormalsToTemporaryBuffer(secondNormals);
            testCandidate.AddNormalsToTemporaryBuffer(thirdNormals);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);   
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(new float[0]);
        
            testCandidate.BuildChunkData();
            float[] result = testCandidate.GetNormals();    

            yield return null;     

            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EqualTo(1.4f));
            Assert.That(result[1], Is.EqualTo(2.3f));
            Assert.That(result[2], Is.EqualTo(5.4f));
            Assert.That(result[3], Is.EqualTo(7.1f));
            Assert.That(result[4], Is.EqualTo(0.4f));
            Assert.That(result[5], Is.EqualTo(1.5f));           
        }

        [UnityTest]
        public IEnumerator FlattenedUvCoordinatesAreCalculatedFromTemporaryBuffer() 
        {
            VisualChunkData testCandidate = new VisualChunkData();
        
            float[] uvCoordinates = { 0.4f, 1.5f };
            float[] secondUvCoordinates = { 9.1f, 4.4f };
            float[] thirdUvCoordinates = { 7.7f, 8.3f };     
        
            testCandidate.SetUpWithNumberOfBlocksInChunk(3);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(uvCoordinates);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(secondUvCoordinates);
            testCandidate.AddUvCoordinatesToTemporaryBuffer(thirdUvCoordinates);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);
            testCandidate.AddNormalsToTemporaryBuffer(new float[0]);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddIndicesToTemporaryBuffer(new int[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);
            testCandidate.AddVerticesToTemporaryBuffer(new float[0]);   
        
            testCandidate.BuildChunkData();
            float[] result = testCandidate.GetUvCoordinates();

            yield return null; 

            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EqualTo(0.4f));
            Assert.That(result[1], Is.EqualTo(1.5f));
            Assert.That(result[2], Is.EqualTo(9.1f));
            Assert.That(result[3], Is.EqualTo(4.4f));
            Assert.That(result[4], Is.EqualTo(7.7f));
            Assert.That(result[5], Is.EqualTo(8.3f));                     
        }                               
    }    
}