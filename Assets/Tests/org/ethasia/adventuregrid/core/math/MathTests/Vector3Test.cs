using NUnit.Framework;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Math.MathTests
{
    public class Vector3fTest
    {
        [Test]
        public void GettersRetrieveSetComponents() 
        {
            Vector3f testCandidate = new Vector3f(1.0f, 2.0f, 3.0f);
        
            Assert.That(testCandidate.GetX(), Is.EqualTo(1.0f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(2.0f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(3.0f));
        }

        [Test]
        public void SetsComponentsProperly() 
        {
            Vector3f testCandidate = new Vector3f(1.0f, 2.0f, 3.0f);
            Vector3f changedVector = testCandidate.Set(4.5f, 3.2f, 1.5f);

            Assert.That(changedVector.GetX(), Is.EqualTo(4.5f));
            Assert.That(changedVector.GetY(), Is.EqualTo(3.2f));
            Assert.That(changedVector.GetZ(), Is.EqualTo(1.5f));
        } 

        [Test]
        public void SquaredLengthIsCalculatedProperly() 
        {
            Vector3f testCandidate = new Vector3f(4.5f, 3.2f, 1.5f);   
        
            float expected = 4.5f * 4.5f + 3.2f * 3.2f + 1.5f * 1.5f;

            Assert.That(testCandidate.GetSquaredLength(), Is.EqualTo(expected));
        }  

        [Test]
        public void ScalesCorrectly() 
        {
            Vector3f testCandidate = new Vector3f(2.2f, 5.1f, 3.7f);
        
            float expectedX = 2.2f * 0.6f;
            float expectedY = 5.1f * 0.6f;
            float expectedZ = 3.7f * 0.6f;
        
            testCandidate.Scale(0.6f);

            Assert.That(testCandidate.GetX(), Is.EqualTo(expectedX));
            Assert.That(testCandidate.GetY(), Is.EqualTo(expectedY));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(expectedZ));                
        } 

        [Test]
        public void ImmutableScaleDoesNotChangeVector() 
        {
            Vector3f testCandidate = new Vector3f(4.9f, 2.3f, 0.3f);
        
            float expectedX = 4.9f * 0.4f;
            float expectedY = 2.3f * 0.4f;
            float expectedZ = 0.3f * 0.4f;   
        
            Vector3f result = testCandidate.ScaleImmutable(0.4f);

            Assert.That(testCandidate.GetX(), Is.EqualTo(4.9f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(2.3f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(0.3f));   
        
            Assert.That(result.GetX(), Is.EqualTo(expectedX));
            Assert.That(result.GetY(), Is.EqualTo(expectedY));
            Assert.That(result.GetZ(), Is.EqualTo(expectedZ));             
        }

        [Test]
        public void NormalizeSetsVectorLengthToOne() 
        {    
            Vector3f testCandidate = new Vector3f(2.2f, 5.1f, 3.7f);
        
            testCandidate.Normalize();
            float result = testCandidate.GetSquaredLength();

            Assert.That(result, Is.EqualTo(1.0f));
        }  

        [Test]
        public void AddingAddsVectorComponents() 
        {  
            Vector3f testCandidate = new Vector3f(2.2f, 5.1f, 3.7f);
            Vector3f toAdd = new Vector3f(1.0f, 2.0f, 3.0f);
        
            testCandidate = testCandidate.Add(toAdd);

            Assert.That(testCandidate.GetX(), Is.EqualTo(3.2f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(7.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(6.7f));               
        }   

        [Test]
        public void SubtractingVectorsSubtractsComponents() 
        {  
            Vector3f testCandidate = new Vector3f(2.2f, 5.1f, 3.7f);
            Vector3f toSubtract = new Vector3f(1.0f, 2.0f, 3.0f);

            testCandidate = testCandidate.Subtract(toSubtract);  

            Assert.That(System.Math.Abs(1.2f - testCandidate.GetX()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(3.1f - testCandidate.GetY()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(0.7f - testCandidate.GetZ()), Is.LessThan(0.001f));
        }   

        [Test]
        public void DotProductIsCalculatedCorrectly() 
        {  
            Vector3f testCandidate = new Vector3f(2.2f, 5.1f, 3.7f);
            Vector3f secondVector = new Vector3f(4.5f, 3.2f, 1.5f); 
        
            float result = testCandidate.Dot(secondVector);
            float expected = 2.2f * 4.5f + 5.1f * 3.2f + 3.7f * 1.5f;

            Assert.That(result, Is.EqualTo(expected));
        } 

        [Test]
        public void CrossProductIsCalculatedCorrectly() 
        {  
            Vector3f testCandidate = new Vector3f(2.2f, 5.1f, 3.7f);
            Vector3f secondVector = new Vector3f(4.5f, 3.2f, 1.5f); 

            testCandidate = testCandidate.Cross(secondVector);
        
            float expectedX = 5.1f * 1.5f - 3.7f * 3.2f;
            float expectedY = 3.7f * 4.5f - 2.2f * 1.5f;
            float expectedZ = 2.2f * 3.2f - 5.1f * 4.5f; 

            Assert.That(System.Math.Abs(expectedX - testCandidate.GetX()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(expectedY - testCandidate.GetY()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(expectedZ - testCandidate.GetZ()), Is.LessThan(0.001f));          
        }  

        [Test]
        public void ImmutableAdditionDoesNotChangeOriginalVector() 
        { 
            Vector3f testCandidate = new Vector3f(1.5f, 9.1f, 4.3f);
            Vector3f toAdd = new Vector3f(2.0f, 4.0f, 1.0f);
        
            Vector3f result = testCandidate.AddImmutable(toAdd);

            Assert.That(testCandidate.GetX(), Is.EqualTo(1.5f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(9.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(4.3f));
        
            Assert.That(result.GetX(), Is.EqualTo(3.5f));
            Assert.That(result.GetY(), Is.EqualTo(13.1f));
            Assert.That(result.GetZ(), Is.EqualTo(5.3f));            
        }  

        [Test]
        public void ImmutableSubtractionDoesNotChangeOriginalVector() 
        { 
            Vector3f testCandidate = new Vector3f(1.5f, 9.1f, 4.3f);
            Vector3f toSubtract = new Vector3f(2.0f, 4.0f, 1.0f);

            Vector3f result = testCandidate.SubtractImmutable(toSubtract);

            Assert.That(testCandidate.GetX(), Is.EqualTo(1.5f));
            Assert.That(testCandidate.GetY(), Is.EqualTo(9.1f));
            Assert.That(testCandidate.GetZ(), Is.EqualTo(4.3f));     
        
            Assert.That(System.Math.Abs(-0.5f - result.GetX()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(5.1f - result.GetY()), Is.LessThan(0.001f));
            Assert.That(System.Math.Abs(3.3f - result.GetZ()), Is.LessThan(0.001f));           
        }  

        [Test]
        public void ResultBufferIsFilledAfterBufferedAddition() 
        { 
            Vector3f testCandidate = new Vector3f(1.5f, 9.1f, 4.3f);
            Vector3f toAdd = new Vector3f(2.0f, 4.0f, 1.0f);
        
            testCandidate.AddImmutableBufferResult(toAdd);

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
            Vector3f testCandidate = new Vector3f(5.2f, -1.1f, -3.1f);
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