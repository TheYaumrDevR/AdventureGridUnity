using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen.Tests
{
    public class PlayerSpawnPointFinderTest
    {
        PlayerSpawnPointFinder testCandidate = new PlayerSpawnPointFinder();

        [Test]
        public void TestThatSpawnPointIsSetOnBottomRightFromCenter()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[1, 2] = 5;
            heightMap[2, 2] = 5;
            heightMap[0, 3] = 5;
            heightMap[1, 3] = 5;
            heightMap[2, 3] = 5;
            heightMap[3, 3] = 5;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(2));
            Assert.That(result.Y, Is.EqualTo(5));
            Assert.That(result.Z, Is.EqualTo(2));
        }

        [Test]
        public void TestThatSpawnPointIsSetAboveFromCenter()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[0, 0] = 41;
            heightMap[0, 1] = 42;
            heightMap[1, 0] = 40;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(40));
            Assert.That(result.Z, Is.EqualTo(0));
        }  

        [Test]
        public void TestThatSpawnPointIsSetBelowCenter()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[1, 2] = 111;
            heightMap[1, 3] = 111;
            heightMap[2, 3] = 111;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(1));
            Assert.That(result.Y, Is.EqualTo(111));
            Assert.That(result.Z, Is.EqualTo(2));
        }   

        [Test]
        public void TestThatSpawnPointIsSetLeftOfCenter()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[0, 1] = 213;
            heightMap[0, 2] = 214;
            heightMap[0, 3] = 215;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(0));
            Assert.That(result.Y, Is.EqualTo(213));
            Assert.That(result.Z, Is.EqualTo(1));
        }      

        [Test]
        public void TestThatSpawnPointIsSetRightOfCenter()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[2, 1] = 169;
            heightMap[2, 0] = 168;
            heightMap[1, 0] = 169;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(2));
            Assert.That(result.Y, Is.EqualTo(169));
            Assert.That(result.Z, Is.EqualTo(1));
        }                   

        [Test]
        public void TestThatSpawnPointIsSetBottomLeftFromCenter()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[0, 2] = 72;
            heightMap[0, 3] = 71;
            heightMap[1, 2] = 72;
            heightMap[1, 3] = 71;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(0));
            Assert.That(result.Y, Is.EqualTo(72));
            Assert.That(result.Z, Is.EqualTo(2));
        }  

        [Test]
        public void TestThatSpawnPointIsSetOnBottomRightCorner()
        {
            Island island = new Island(4);
            int[,] heightMap = new int[4, 4];

            heightMap[3, 3] = 169;
            heightMap[3, 2] = 170;
            heightMap[3, 1] = 170;
            heightMap[3, 0] = 169;

            testCandidate.DeterminePlayerSpawnPoint(island, heightMap);

            BlockPosition result = island.PlayerSpawnPosition;

            Assert.That(result.X, Is.EqualTo(3));
            Assert.That(result.Y, Is.EqualTo(169));
            Assert.That(result.Z, Is.EqualTo(3));
        }                       
    }
}