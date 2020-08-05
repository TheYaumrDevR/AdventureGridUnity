using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class RockBlockTest
    {
        [UnityTest]
        public IEnumerator BlockTypeIsRock() 
        {
            RockBlock testCandidate = RockBlock.GetInstance();

            yield return null;

            Assert.That(testCandidate, Is.Not.Null);
            Assert.That(testCandidate.GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
        }

        [UnityTest]
        public IEnumerator AllBlockFacesAreCovering()
        {
            RockBlock testCandidate = RockBlock.GetInstance();

            yield return null;

            Assert.IsTrue(testCandidate.GetFrontFaceIsCovering());
            Assert.IsTrue(testCandidate.GetRightFaceIsCovering());
            Assert.IsTrue(testCandidate.GetBackFaceIsCovering());
            Assert.IsTrue(testCandidate.GetLeftFaceIsCovering());
            Assert.IsTrue(testCandidate.GetBottomFaceIsCovering());
            Assert.IsTrue(testCandidate.GetTopFaceIsCovering());
        }
    }
}