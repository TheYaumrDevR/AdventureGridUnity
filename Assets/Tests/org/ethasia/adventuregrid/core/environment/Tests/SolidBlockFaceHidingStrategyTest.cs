using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class SolidBlockFaceHidingStrategyTest
    {
        [UnityTest]
        public IEnumerator LeftFaceIsHiddenWhenCovered() 
        {
            SolidBlockFaceHidingStrategy testCandidate = new SolidBlockFaceHidingStrategy();

            Block coveredBlock = RockBlock.GetInstance();
            Block coveringBlock = EarthBlock.GetInstance();

            bool result = testCandidate.FaceIsHidden(coveredBlock, coveringBlock, BlockFaceDirections.LEFT);

            yield return null;

            Assert.IsTrue(result);
        }

        [UnityTest]
        public IEnumerator LeftFaceIsShownWhenUncovered() 
        {
            SolidBlockFaceHidingStrategy testCandidate = new SolidBlockFaceHidingStrategy();

            Block coveredBlock = RockBlock.GetInstance();
            Block coveringBlock = AirBlock.GetInstance();

            bool result = testCandidate.FaceIsHidden(coveredBlock, coveringBlock, BlockFaceDirections.LEFT);

            yield return null;

            Assert.IsFalse(result);            
        }

        [UnityTest]
        public IEnumerator LeftFaceIsShownWhenItsNotCovering() 
        {
            SolidBlockFaceHidingStrategy testCandidate = new SolidBlockFaceHidingStrategy();

            Block coveredBlock = AirBlock.GetInstance();
            Block coveringBlock = EarthBlock.GetInstance();

            bool result = testCandidate.FaceIsHidden(coveredBlock, coveringBlock, BlockFaceDirections.LEFT);

            yield return null;

            Assert.IsFalse(result);
        }        
    }
}
