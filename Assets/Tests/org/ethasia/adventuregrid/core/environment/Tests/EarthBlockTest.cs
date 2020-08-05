using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class EarthBlockTest
    {
        [UnityTest]
        public IEnumerator BlockTypeIsEarth() 
        {
            EarthBlock testCandidate = EarthBlock.GetInstance();

            yield return null;

            Assert.That(testCandidate, Is.Not.Null);
            Assert.That(testCandidate.GetBlockType(), Is.EqualTo(BlockTypes.EARTH));
        }

        [UnityTest]
        public IEnumerator AllBlockFacesAreCovering()
        {
            EarthBlock testCandidate = EarthBlock.GetInstance();

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