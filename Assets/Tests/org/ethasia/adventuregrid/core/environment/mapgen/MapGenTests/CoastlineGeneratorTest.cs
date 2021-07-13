using NUnit.Framework;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen.Tests
{
    public class CoastlineGeneratorTest
    {

        [Test]
        public void TestThatTwoEqualSectorBoundariesAreEqual()
        {
            CoastlineGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 4, 7, 9, 3);
            CoastlineGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineGenerator.CoastLineCreationSectorBoundary(1, 4, 7, 9, 3);

            Assert.That(firstBoundary, Is.EqualTo(secondBoundary));
        }

        [Test]
        public void TestThatTwoDifferentSectorBoundariesAreNotEqual()
        {
            CoastlineGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 4, 7, 9, 3);
            CoastlineGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineGenerator.CoastLineCreationSectorBoundary(1, 5, 7, 9, 4);

            Assert.That(firstBoundary, Is.Not.EqualTo(secondBoundary));
        }        
    }
}