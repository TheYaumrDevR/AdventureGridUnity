using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Blockdecorators.Tests
{
    public class RotationDataBlockDecoratorTest
    {
        RotationDataBlockDecorator testCandidate = new RotationDataBlockDecorator(null);

        [Test]
        public void TestRotationStateIsCorrectlySetAfterRotations()
        {
            testCandidate.RotatePositiveAroundXAxis();
            testCandidate.RotateNegativeAroundYAxis();
            testCandidate.RotatePositiveAroundZAxis();
        }
    }
}