using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class AirBlockTest
    {
        [UnityTest]
        public IEnumerator BlockTypeIsAir() 
        {
            AirBlock testCandidate = AirBlock.GetInstance();

            yield return null;

            Assert.That(testCandidate, Is.Not.Null);
            Assert.That(testCandidate.GetBlockType(), Is.EqualTo(BlockTypes.AIR));
        }

        [UnityTest]
        public IEnumerator BlockFacesAreNotCoveringAnything()
        {
            AirBlock testCandidate = AirBlock.GetInstance();

            yield return null;

            Assert.IsFalse(testCandidate.GetFrontFaceIsCovering());
            Assert.IsFalse(testCandidate.GetRightFaceIsCovering());
            Assert.IsFalse(testCandidate.GetBackFaceIsCovering());
            Assert.IsFalse(testCandidate.GetLeftFaceIsCovering());
            Assert.IsFalse(testCandidate.GetBottomFaceIsCovering());
            Assert.IsFalse(testCandidate.GetTopFaceIsCovering());
        }
    }
}
