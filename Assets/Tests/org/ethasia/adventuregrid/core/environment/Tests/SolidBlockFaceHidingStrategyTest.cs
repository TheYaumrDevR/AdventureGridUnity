using NUnit.Framework;
using System.Collections;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class SolidBlockFaceHidingStrategyTest
    {
        [Test]
        public void LeftFaceIsHiddenWhenCovered() 
        {
            SolidBlockFaceHidingStrategy testCandidate = new SolidBlockFaceHidingStrategy();

            Block coveredBlock = RockBlock.GetInstance();
            Block coveringBlock = EarthBlock.GetInstance();

            bool result = testCandidate.FaceIsHidden(coveredBlock, coveringBlock, BlockFaceDirections.LEFT);

            Assert.IsTrue(result);
        }

        [Test]
        public void LeftFaceIsShownWhenUncovered() 
        {
            SolidBlockFaceHidingStrategy testCandidate = new SolidBlockFaceHidingStrategy();

            Block coveredBlock = RockBlock.GetInstance();
            Block coveringBlock = AirBlock.GetInstance();

            bool result = testCandidate.FaceIsHidden(coveredBlock, coveringBlock, BlockFaceDirections.LEFT);

            Assert.IsFalse(result);            
        }

        [Test]
        public void LeftFaceIsShownWhenItsNotCovering() 
        {
            SolidBlockFaceHidingStrategy testCandidate = new SolidBlockFaceHidingStrategy();

            Block coveredBlock = AirBlock.GetInstance();
            Block coveringBlock = EarthBlock.GetInstance();

            bool result = testCandidate.FaceIsHidden(coveredBlock, coveringBlock, BlockFaceDirections.LEFT);

            Assert.IsFalse(result);
        }        
    }
}
