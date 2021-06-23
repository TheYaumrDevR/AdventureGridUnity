using NUnit.Framework;
using UnityEngine;

namespace Org.Ethasia.Adventuregrid.Technical.Rendering.RenderingTests
{
    public class NewTestScript
    {

        [Test]
        public void TestThatConvertingFlatFloat3ArrayToVectorArrayCreatesCorrectVectors()
        {
            float[] toConvert = {3.4f, 1.2f, 1.5f, 2.4f, 2.3f, 0.3f, 1.7f, 10.0f, 5.5f};

            Vector3[] result = RenderingTypeConverter.ConvertFlatFloatArrayToVector3Array(toConvert);

            Assert.That(result[0].x, Is.EqualTo(3.4f));
            Assert.That(result[0].y, Is.EqualTo(1.2f));
            Assert.That(result[0].z, Is.EqualTo(1.5f));

            Assert.That(result[1].x, Is.EqualTo(2.4f));
            Assert.That(result[1].y, Is.EqualTo(2.3f));
            Assert.That(result[1].z, Is.EqualTo(0.3f));

            Assert.That(result[2].x, Is.EqualTo(1.7f));
            Assert.That(result[2].y, Is.EqualTo(10.0f));
            Assert.That(result[2].z, Is.EqualTo(5.5f));            
        }

        [Test]
        public void TestThatConvertingFlatFloat2ArrayToVectorArrayCreatesCorrectVectors()
        {
            float[] toConvert = {1.3f, 2.3f, 1.3f, 5.7f, 10.9f, 0.4f};

            Vector2[] result = RenderingTypeConverter.ConvertFlatFloatArrayToVector2Array(toConvert);

            Assert.That(result[0].x, Is.EqualTo(1.3f));
            Assert.That(result[0].y, Is.EqualTo(2.3f));

            Assert.That(result[1].x, Is.EqualTo(1.3f));
            Assert.That(result[1].y, Is.EqualTo(5.7f));

            Assert.That(result[2].x, Is.EqualTo(10.9f));
            Assert.That(result[2].y, Is.EqualTo(0.4f));
        }        
    }
}