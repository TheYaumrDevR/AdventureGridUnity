using NUnit.Framework;
using System.Collections.Generic;

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
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(0, 4, 7, 9, 3);
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(1, 4, 7, 9, 3);

            Assert.That(firstBoundary, Is.EqualTo(secondBoundary));
        }

        [Test]
        public void TestThatTwoDifferentSectorBoundariesAreNotEqual()
        {
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(0, 4, 7, 9, 3);
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(1, 5, 7, 9, 4);

            Assert.That(firstBoundary, Is.Not.EqualTo(secondBoundary));
        }        

        [Test]
        public void Test1x1IslandGeneratesNoBlockOnZeroRng()
        {
            int[] randomNumbersToGenerate = {100, 0};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            CoastlineHeightMapGenerator testCandidate = new CoastlineHeightMapGenerator();

            HashSet<BlockPosition> result = testCandidate.GenerateCoastline(1);
            Assert.That(result.Contains(new BlockPosition(0, 100, 0)), Is.False);
        }

        [Test]
        public void Test1x1IslandGeneratesBlockOnOneRng()
        {
            int[] randomNumbersToGenerate = {100, 1};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            CoastlineHeightMapGenerator testCandidate = new CoastlineHeightMapGenerator();

            HashSet<BlockPosition> result = testCandidate.GenerateCoastline(1);
            Assert.That(result.Contains(new BlockPosition(0, 100, 0)), Is.True);
        }        

        [Test]
        public void Test2x2IslandGenerationWithAllBlocks()
        {
            int[] randomNumbersToGenerate = {100, 4, 0, 0, 3, 3, 1, 1, 3, 1, 0, 2};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            CoastlineHeightMapGenerator testCandidate = new CoastlineHeightMapGenerator();

            HashSet<BlockPosition> result = testCandidate.GenerateCoastline(2);

            Assert.That(result.Contains(new BlockPosition(0, 100, 0)), Is.True);
            Assert.That(result.Contains(new BlockPosition(1, 100, 0)), Is.True);
            Assert.That(result.Contains(new BlockPosition(0, 100, 1)), Is.True);
            Assert.That(result.Contains(new BlockPosition(1, 100, 1)), Is.True);
        }   

        [Test]
        public void Test2x2IslandGenerationWithThreeBlocks()
        {
            int[] randomNumbersToGenerate = {110, 3, 3, 2, 3, 0};
            SetupRngMockWithNumbers(randomNumbersToGenerate);

            CoastlineHeightMapGenerator testCandidate = new CoastlineHeightMapGenerator();

            HashSet<BlockPosition> result = testCandidate.GenerateCoastline(2);

            Assert.That(result.Contains(new BlockPosition(0, 110, 0)), Is.True);
            Assert.That(result.Contains(new BlockPosition(1, 110, 0)), Is.False);
            Assert.That(result.Contains(new BlockPosition(0, 110, 1)), Is.True);
            Assert.That(result.Contains(new BlockPosition(1, 110, 1)), Is.True);
        }   

        [Test]
        public void TestThatSmallerCoastlineSectorBoundariesAreIdentified()
        {
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(0, 0, 7, 8, 16);
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(1, 8, 24, 17, 33);

            Assert.That(firstBoundary.IsSmallerThan(secondBoundary), Is.True);
        }

        [Test]
        public void TestThatEqualSizeSectorBoundaryIsNotSmaller()
        {
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(0, 10, 18, 17, 34);
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(1, 21, 29, 30, 47);

            Assert.That(firstBoundary.IsSmallerThan(secondBoundary), Is.False);
        }   

        [Test]
        public void TestThatLargerSizeSectorBoundaryIsNotSmaller()
        {
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary firstBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(0, 56, 67, 16, 27);
            CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary secondBoundary = new CoastlineHeightMapGenerator.CoastLineCreationSectorBoundary(1, 5, 10, 11, 16);

            Assert.That(firstBoundary.IsSmallerThan(secondBoundary), Is.False);
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

            CoastlineHeightMapGenerator testCandidate = new CoastlineHeightMapGenerator();

            HashSet<BlockPosition> result = testCandidate.GenerateCoastline(8);

            Assert.That(result.Contains(new BlockPosition(2, 112, 3)), Is.True);
            Assert.That(result.Contains(new BlockPosition(1, 112, 3)), Is.False);
            Assert.That(result.Contains(new BlockPosition(2, 112, 4)), Is.True);
            Assert.That(result.Contains(new BlockPosition(2, 112, 5)), Is.False);
            Assert.That(result.Contains(new BlockPosition(3, 112, 3)), Is.True);
            Assert.That(result.Contains(new BlockPosition(3, 112, 4)), Is.False);
            Assert.That(result.Contains(new BlockPosition(3, 112, 5)), Is.True);
            Assert.That(result.Contains(new BlockPosition(4, 112, 1)), Is.False);
            Assert.That(result.Contains(new BlockPosition(4, 112, 2)), Is.True);
            Assert.That(result.Contains(new BlockPosition(4, 112, 6)), Is.True);        
            Assert.That(result.Contains(new BlockPosition(5, 112, 2)), Is.True);
            Assert.That(result.Contains(new BlockPosition(5, 112, 6)), Is.True);        
            Assert.That(result.Contains(new BlockPosition(6, 112, 2)), Is.True);
            Assert.That(result.Contains(new BlockPosition(6, 112, 5)), Is.True);     
            Assert.That(result.Contains(new BlockPosition(6, 112, 6)), Is.True);  
            Assert.That(result.Contains(new BlockPosition(7, 112, 3)), Is.True);     
            Assert.That(result.Contains(new BlockPosition(7, 112, 4)), Is.True);                                    
        }

        private void SetupRngMockWithNumbers(int[] randomNumbersToGenerate)
        {
            RandomNumberGeneratorMock rngMock = new RandomNumberGeneratorMock(randomNumbersToGenerate);
            MockCoreFactory mockCoreFactory = new MockCoreFactory(rngMock);
            CoreFactory.SetInstance(mockCoreFactory);
        }                     
    }
}