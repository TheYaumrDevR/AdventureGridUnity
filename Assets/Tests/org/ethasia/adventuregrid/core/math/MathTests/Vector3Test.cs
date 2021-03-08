using NUnit.Framework;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Math.MathTests
{
    public class Vector3Test
    {
        [UnityTest]
        public IEnumerator GettersRetrieveSetComponents() 
        {
            Vector3 testCandidate = new Vector3(1.0f, 2.0f, 3.0f);

            yield return null;
        
            Assert.That(testCandidate.GetX(), Is.EqualTo(1.0f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(2.0f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(3.0f));
        }

        [UnityTest]
        public IEnumerator SetsComponentsProperly() 
        {
            Vector3 testCandidate = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 changedVector = testCandidate.Set(4.5f, 3.2f, 1.5f);
        
            yield return null;

            Assert.That(changedVector.GetX(), Is.EqualTo(4.5f));
            Assert.That(changedVector.GetY(), Is.EqualTo(3.2f));
            Assert.That(changedVector.GetZ(), Is.EqualTo(1.5f));
        } 

        [UnityTest]
        public IEnumerator SquaredLengthIsCalculatedProperly() 
        {
            Vector3 testCandidate = new Vector3(4.5f, 3.2f, 1.5f);   
        
            float expected = 4.5f * 4.5f + 3.2f * 3.2f + 1.5f * 1.5f;

            yield return null;

            Assert.That(testCandidate.GetSquaredLength(), Is.EqualTo(expected));
        }  

        [UnityTest]
        public IEnumerator ScalesCorrectly() 
        {
            Vector3 testCandidate = new Vector3(2.2f, 5.1f, 3.7f);
        
            float expectedX = 2.2f * 0.6f;
            float expectedY = 5.1f * 0.6f;
            float expectedZ = 3.7f * 0.6f;
        
            testCandidate.Scale(0.6f);

            yield return null;

            Assert.That(testCandidate.GetX(), Is.EqualTo(expectedX));
            Assert.That(testCandidate.GetY(), Is.EqualTo(expectedY));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(expectedZ));                
        } 

        [UnityTest]
        public IEnumerator ImmutableScaleDoesNotChangeVector() 
        {
            Vector3 testCandidate = new Vector3(4.9f, 2.3f, 0.3f);
        
            float expectedX = 4.9f * 0.4f;
            float expectedY = 2.3f * 0.4f;
            float expectedZ = 0.3f * 0.4f;   
        
            Vector3 result = testCandidate.ScaleImmutable(0.4f);

            yield return null;

            Assert.That(testCandidate.GetX(), Is.EqualTo(4.9f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(2.3f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(0.3f));   
        
            Assert.That(result.GetX(), Is.EqualTo(expectedX));
            Assert.That(result.GetY(), Is.EqualTo(expectedY));
            Assert.That(result.GetZ(), Is.EqualTo(expectedZ));             
        }

        [UnityTest]
        public IEnumerator NormalizeSetsVectorLengthToOne() 
        {    
            Vector3 testCandidate = new Vector3(2.2f, 5.1f, 3.7f);
        
            testCandidate.Normalize();
            float result = testCandidate.GetSquaredLength();

            yield return null;

            Assert.That(result, Is.EqualTo(1.0f));
        }  

        [UnityTest]
        public IEnumerator AddingAddsVectorComponents() 
        {  
            Vector3 testCandidate = new Vector3(2.2f, 5.1f, 3.7f);
            Vector3 toAdd = new Vector3(1.0f, 2.0f, 3.0f);
        
            testCandidate = testCandidate.Add(toAdd);

            yield return null;

            Assert.That(testCandidate.GetX(), Is.EqualTo(3.2f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(7.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(6.7f));               
        }   

        [UnityTest]
        public IEnumerator SubtractingVectorsSubtractsComponents() 
        {  
            Vector3 testCandidate = new Vector3(2.2f, 5.1f, 3.7f);
            Vector3 toSubtract = new Vector3(1.0f, 2.0f, 3.0f);

            testCandidate = testCandidate.Subtract(toSubtract);  

            yield return null;

            Assert.That(System.Math.Abs(1.2f - testCandidate.GetX()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(3.1f - testCandidate.GetY()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(0.7f - testCandidate.GetZ()), Is.LessThan(0.001f));
        }   

        [UnityTest]
        public IEnumerator DotProductIsCalculatedCorrectly() 
        {  
            Vector3 testCandidate = new Vector3(2.2f, 5.1f, 3.7f);
            Vector3 secondVector = new Vector3(4.5f, 3.2f, 1.5f); 
        
            float result = testCandidate.Dot(secondVector);
            float expected = 2.2f * 4.5f + 5.1f * 3.2f + 3.7f * 1.5f;

            yield return null;

            Assert.That(result, Is.EqualTo(expected));
        } 

        [UnityTest]
        public IEnumerator CrossProductIsCalculatedCorrectly() 
        {  
            Vector3 testCandidate = new Vector3(2.2f, 5.1f, 3.7f);
            Vector3 secondVector = new Vector3(4.5f, 3.2f, 1.5f); 

            testCandidate = testCandidate.Cross(secondVector);
        
            float expectedX = 5.1f * 1.5f - 3.7f * 3.2f;
            float expectedY = 3.7f * 4.5f - 2.2f * 1.5f;
            float expectedZ = 2.2f * 3.2f - 5.1f * 4.5f; 

            yield return null;

            Assert.That(System.Math.Abs(expectedX - testCandidate.GetX()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(expectedY - testCandidate.GetY()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(expectedZ - testCandidate.GetZ()), Is.LessThan(0.001f));          
        }  

        [UnityTest]
        public IEnumerator ImmutableAdditionDoesNotChangeOriginalVector() 
        { 
            Vector3 testCandidate = new Vector3(1.5f, 9.1f, 4.3f);
            Vector3 toAdd = new Vector3(2.0f, 4.0f, 1.0f);
        
            Vector3 result = testCandidate.AddImmutable(toAdd);

            yield return null;

            Assert.That(testCandidate.GetX(), Is.EqualTo(1.5f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(9.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(4.3f));
        
            Assert.That(result.GetX(), Is.EqualTo(3.5f));
            Assert.That(result.GetY(), Is.EqualTo(13.1f));
            Assert.That(result.GetZ(), Is.EqualTo(5.3f));            
        }  

        [UnityTest]
        public IEnumerator ImmutableSubtractionDoesNotChangeOriginalVector() 
        { 
            Vector3 testCandidate = new Vector3(1.5f, 9.1f, 4.3f);
            Vector3 toSubtract = new Vector3(2.0f, 4.0f, 1.0f);

            Vector3 result = testCandidate.SubtractImmutable(toSubtract);

            yield return null;

            Assert.That(testCandidate.GetX(), Is.EqualTo(1.5f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(9.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(4.3f));     
        
            Assert.That(System.Math.Abs(-0.5f - result.GetX()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(5.1f - result.GetY()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(3.3f - result.GetZ()), Is.LessThan(0.001f));           
        }  

        [UnityTest]
        public IEnumerator ResultBufferIsFilledAfterBufferedAddition() 
        { 
            Vector3 testCandidate = new Vector3(1.5f, 9.1f, 4.3f);
            Vector3 toAdd = new Vector3(2.0f, 4.0f, 1.0f);
        
            testCandidate.AddImmutableBufferResult(toAdd);

            yield return null;

            Assert.That(testCandidate.GetBufferedResultX(), Is.EqualTo(3.5f));
            Assert.That(testCandidate.GetBufferedResultY(), Is.EqualTo(13.1f));
            Assert.That(testCandidate.GetBufferedResultZ(), Is.EqualTo(5.3f));    
        
            Assert.That(testCandidate.GetX(), Is.EqualTo(1.5f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(9.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(4.3f));              
        }       

        [Test]
        public void AddingPositionBufferedAddsPositionComponentsToBuffer()
        {
            Vector3 testCandidate = new Vector3(5.2f, -1.1f, -3.1f);
            Position3 toAdd = new Position3(1.5f, 1.1f, 2.8f);

            float expectedZ = -3.1f + 2.8f;

            testCandidate.AddImmutableBufferResult(toAdd);

            Assert.That(testCandidate.GetBufferedResultX(), Is.EqualTo(6.7f));
            Assert.That(testCandidate.GetBufferedResultY(), Is.EqualTo(0.0f));
            Assert.That(testCandidate.GetBufferedResultZ(), Is.EqualTo(expectedZ));    

            Assert.That(testCandidate.GetX(), Is.EqualTo(5.2f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(-1.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(-3.1f));  
        }                                                                  
    }
}