using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Math.MathTests
{
    public class FastMathTest
    {
        [Test]
        public void TestFloorCalculatesPositiveFloor()
        {
            int result = FastMath.Floor(19.7);

            Assert.That(result, Is.EqualTo(19));
        }

        [Test]
        public void TestFloorCalculatesNegativeFloor()
        {
            int result = FastMath.Floor(-8.5);

            Assert.That(result, Is.EqualTo(-9));
        }

        [Test]
        public void TestFloorCalculatesFloorForInteger()
        {
            int result = FastMath.Floor(1239.0);

            Assert.That(result, Is.EqualTo(1239));
        }

        [Test]
        public void TestCeilCalculatesPositiveCeil()
        {
            int result = FastMath.Ceil(543.1);

            Assert.That(result, Is.EqualTo(544));
        }

        [Test]
        public void TestCeilCalculatesNegativeCeil()
        {
            int result = FastMath.Ceil(-474.223);

            Assert.That(result, Is.EqualTo(-474));
        }  

        [Test]
        public void TestCeilCalculatesCeilForInteger()
        {
            int result = FastMath.Ceil(-473.0);

            Assert.That(result, Is.EqualTo(-473));
        }                
    }
}