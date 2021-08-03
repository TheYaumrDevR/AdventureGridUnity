using NUnit.Framework;
using System.Collections.Generic;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen.Tests
{

    public class FloodFillTest
    {

        [Test]
        public void TestThatAllOutsideCoastlineBlocksAreMarked()
        {
            HashSet<BlockPosition> coastLineHeightMap = new HashSet<BlockPosition>();

            BlockPosition blockPositionOne = new BlockPosition(1, 67, 0);
            BlockPosition blockPositionTwo = new BlockPosition(2, 67, 0);
            BlockPosition blockPositionThree = new BlockPosition(3, 67, 0);
            BlockPosition blockPositionFour = new BlockPosition(4, 67, 1);
            BlockPosition blockPositionFive = new BlockPosition(4, 67, 2);
            BlockPosition blockPositionSix = new BlockPosition(3, 67, 3);
            BlockPosition blockPositionSeven = new BlockPosition(2, 67, 4);
            BlockPosition blockPositionEight = new BlockPosition(1, 67, 3);
            BlockPosition blockPositionNine = new BlockPosition(0, 67, 3);
            BlockPosition blockPositionTen = new BlockPosition(0, 67, 2);
            BlockPosition blockPositionEleven = new BlockPosition(1, 67, 1);

            coastLineHeightMap.Add(blockPositionOne);
            coastLineHeightMap.Add(blockPositionTwo);
            coastLineHeightMap.Add(blockPositionThree);
            coastLineHeightMap.Add(blockPositionFour);
            coastLineHeightMap.Add(blockPositionFive);
            coastLineHeightMap.Add(blockPositionSix);
            coastLineHeightMap.Add(blockPositionSeven);
            coastLineHeightMap.Add(blockPositionEight);
            coastLineHeightMap.Add(blockPositionNine);
            coastLineHeightMap.Add(blockPositionTen);
            coastLineHeightMap.Add(blockPositionEleven);

            FloodFill testCandidate = new FloodFill(coastLineHeightMap);

            testCandidate.MarkBlocksOutsideCoastlineAsEmpty(67, 5);

            BlockPosition expectedEmptyPositionOne = new BlockPosition(0, -1, 0);
            BlockPosition expectedEmptyPositionTwo = new BlockPosition(0, -1, 1);
            BlockPosition expectedEmptyPositionThree = new BlockPosition(0, -1, 4);
            BlockPosition expectedEmptyPositionFour = new BlockPosition(1, -1, 4);
            BlockPosition expectedEmptyPositionFive = new BlockPosition(3, -1, 4);
            BlockPosition expectedEmptyPositionSix = new BlockPosition(4, -1, 4);
            BlockPosition expectedEmptyPositionSeven = new BlockPosition(4, -1, 3);
            BlockPosition expectedEmptyPositionEight = new BlockPosition(4, -1, 0);

            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionOne), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionTwo), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionThree), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionFour), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionFive), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionSix), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionSeven), Is.True);
            Assert.That(coastLineHeightMap.Contains(expectedEmptyPositionEight), Is.True);
        }
    }
}