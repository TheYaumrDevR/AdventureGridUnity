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
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            Island islandToFill = new Island(1);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
        }

        [Test]
        public void Test1x1IslandGeneratesBlockOnOneRng()
        {
            int[] randomNumbersToGenerate = {100, 1};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            Island islandToFill = new Island(1);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
        }        

        [Test]
        public void Test2x2IslandGenerationWithAllBlocks()
        {
            int[] randomNumbersToGenerate = {100, 4, 0, 0, 3, 3, 1, 1, 3, 1, 0, 2};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            Island islandToFill = new Island(2);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 100, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 100, 1)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 100, 1)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
        }   

        [Test]
        public void Test2x2IslandGenerationWithThreeBlocks()
        {
            int[] randomNumbersToGenerate = {110, 3, 3, 2, 3, 0};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            Island islandToFill = new Island(2);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 110, 0)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 110, 0)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(0, 110, 1)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 110, 1)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
        }   

        [Test]
        public void Test8x8IslandGeneration()
        {
            int[] randomNumbersToGenerate = {112, 3, 1, 0, 2, 2, 3, 1, 0, 1, 3, 
                                            2, 3, 3, 0, 0, 3, 1, 1, 2, 2, 3, 1, 
                                            3, 3, 1, 0, 2, 1, 0, 0, 2, 3, 3, 1, 
                                            0, 3, 3, 0, 2, 1, 0, 3, 0, 2, 2, 0, 
                                            3, 0, 1, 3, 2, 1, 0, 3, 2, 3, 1, 2,
                                            1, 0, 2, 0, 1, 2, 1, 3, 2, 0, 3};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            Island islandToFill = new Island(8);
            CoastlineGenerator testCandidate = new CoastlineGenerator();

            testCandidate.GenerateCoastline(islandToFill);

            Assert.That(islandToFill.GetBlockAt(new BlockPosition(2, 112, 3)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(1, 112, 3)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(2, 112, 4)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(2, 112, 5)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(3, 112, 3)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(3, 112, 4)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(3, 112, 5)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(4, 112, 1)).GetBlockType(), Is.EqualTo(BlockTypes.AIR));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(4, 112, 2)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(4, 112, 6)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));        
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(5, 112, 2)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(5, 112, 6)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));        
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(6, 112, 2)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(6, 112, 5)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));     
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(6, 112, 6)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));  
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(7, 112, 3)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));     
            Assert.That(islandToFill.GetBlockAt(new BlockPosition(7, 112, 4)).GetBlockType(), Is.EqualTo(BlockTypes.ROCK));                                    
        }

        private void SetupRngMockWithNumbers(int[] randomNumbersToGenerate)
        {
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate);
            MockCoreFactory mockCoreFactory = new MockCoreFactory(rngMock);
            CoreFactory.SetInstance(mockCoreFactory);
        }                     
    }
}