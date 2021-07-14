using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Math;
using Org.Ethasia.Adventuregrid.Core.Math.Mocks;
using Org.Ethasia.Adventuregrid.Core.Tests;

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

        [Test]
        public void Test1x1IslandGeneratesNoBlockOnZeroRng()
        {
            int[] randomNumbersToGenerate = {100, 0};
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate);
            MockCoreFactory mockCoreFactory = new MockCoreFactory(rngMock);
            CoreFactory.SetInstance(mockCoreFactory);

            Island islandToFill = new Island(1);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
        }

        [Test]
        public void Test1x1IslandGeneratesBlockOnOneRng()
        {
            int[] randomNumbersToGenerate = {100, 1};
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate);
            MockCoreFactory mockCoreFactory = new MockCoreFactory(rngMock);
            CoreFactory.SetInstance(mockCoreFactory);

            Island islandToFill = new Island(1);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
        }        

        [Test]
        public void Test2x2IslandGenerationWithAllBlocks()
        {
            int[] randomNumbersToGenerate = {100, 4, 0, 0, 3, 3, 1, 1, 3, 1, 0, 2};
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate);
            MockCoreFactory mockCoreFactory = new MockCoreFactory(rngMock);
            CoreFactory.SetInstance(mockCoreFactory);

            Island islandToFill = new Island(2);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 1)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 100, 1)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
        }         
    }
}