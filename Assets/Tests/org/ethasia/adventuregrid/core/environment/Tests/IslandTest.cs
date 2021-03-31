using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class IslandTest
    {
        [UnityTest]
        public IEnumerator BlockAtUninitializedPositionIsAir() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(63, 0, 63);
        
            Block blockAt = testCandidate.GetBlockAt(blockPosition);
        
            yield return null;

            Assert.That(blockAt.GetBlockType(), Is.EqualTo(BlockTypes.AIR));      
        }

        [UnityTest]
        public IEnumerator RetrievesPreviouslyPlacedBlock() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = GrassyEarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(63, 0, 63);
        
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            Block blockAt = testCandidate.GetBlockAt(blockPosition);         

            yield return null;     

            Assert.That(blockAt, Is.SameAs(testBlock));
        }  

        [UnityTest]
        public IEnumerator CanPlaceBlockAtMaximumHeight() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = EarthBlock.GetInstance(); 
            BlockPosition blockPosition = new BlockPosition(63, 255, 63);
        
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            Block blockAt = testCandidate.GetBlockAt(blockPosition);      

            yield return null; 

            Assert.That(blockAt, Is.SameAs(testBlock));
        }   

        [UnityTest]
        public IEnumerator CannotPlaceBlockAboveMaximumHeight() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = RockBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(63, 256, 63);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, blockPosition));            
        } 

        [UnityTest]
        public IEnumerator CannotPlaceBlockOutsideXDimension() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = GrassyEarthBlock.GetInstance();  
            BlockPosition blockPosition = new BlockPosition(64, 200, 24);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, blockPosition));                
        } 

        [UnityTest]
        public IEnumerator CannotPlaceBlockOutsideZDimension() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = EarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(54, 13, 64);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, blockPosition));                
        }  

        [UnityTest]
        public IEnumerator CannotGetBlockAboveMaxHeight() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(63, 256, 63);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(blockPosition)); 
        }      

        [UnityTest]
        public IEnumerator CannotGetBlockOutsideXDimension() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(64, 123, 52);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(blockPosition)); 
        }  

        [UnityTest]
        public IEnumerator CannotGetBlockOutsideZDimension() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(32, 222, 64);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(blockPosition)); 
        }  

        [UnityTest]
        public IEnumerator IslandHasCorrectXzDimension() 
        {
            Island testCandidate = new Island(48);
        
            int result = testCandidate.GetXzDimension();
        
            yield return null; 

            Assert.That(result, Is.EqualTo(48));
        } 

        [UnityTest]
        public IEnumerator LeftFaceOfRockBlockIsHiddenWhenCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(5, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(4, 0, 0);
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(true));
        } 

        [UnityTest]
        public IEnumerator LeftFaceOfRockBlockIsVisibleWhenNotCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(5, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(4, 0, 0);            
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        } 

        [UnityTest]
        public IEnumerator BlockFaceIsVisibleWhenItsNotCovering() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(5, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(4, 0, 0);              
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        }    

        [UnityTest]
        public IEnumerator LeftBlockFaceIsVisibleWhenOnLeftIslandEdge() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 0);
        
            Block testBlock = RockBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPosition);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        }

        [UnityTest]
        public IEnumerator FrontFaceOfEarthBlockIsHiddenWhenCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 7);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 8);              
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(true));
        } 

        [UnityTest]
        public IEnumerator FrontFaceOfEarthBlockIsVisibleWhenNotCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 7);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 8);              
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));            
        } 

        [UnityTest]
        public IEnumerator FrontFaceOfBlockIsVisibleWhenNotCovering() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 7);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 8);             
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT,blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        }  

        [UnityTest]
        public IEnumerator FrontFaceOfBlockIsVisibleWhenAtFrontEdgeOfIsland() 
        {              
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 63);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, blockPosition);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        }

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsHiddenWhenCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(45, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(46, 0, 0);              
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(true)); 
        }  

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsVisibleWhenNotCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(45, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(46, 0, 0);               
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        } 

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsVisibleWhenNotFullyCovering() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(45, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(46, 0, 0);             
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));               
        } 

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsVisibleWhenAtRightEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(63, 0, 0);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPosition);

            yield return null;

            Assert.That(result, Is.EqualTo(false));              
        }    

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsHiddenWhenCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 24);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 23);              
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(true));               
        }   

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsVisibleWhenNotCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 24);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 23);               
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));              
        }

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 24);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 23);           

            Block testBlock = AirBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));            
        }  

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsVisibleWhenAtBackEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 0);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPosition);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        } 

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsHiddenWhenCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);              
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock,blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(true));             
        }  

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsVisibleWhenNotCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);             
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, blockPositionOne);   

            yield return null;

            Assert.That(result, Is.EqualTo(false));                     
        }    

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);                 
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        }          

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsVisibleWhenAtBottomEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 0);            
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM,blockPosition);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        } 

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsHiddenWhenCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);              
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock,blockPositionTwo);
            testCandidate.PlaceBlockAt(neighbor, blockPositionOne);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPositionTwo);

            yield return null;

            Assert.That(result, Is.EqualTo(true));            
        }  

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsVisibleWhenNotCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 4, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 5, 0);                
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));            
        } 

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 4, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 5, 0);              
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock,blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPositionOne);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        }  

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsVisibleWhenAtTopEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 255, 0);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPosition);

            yield return null;

            Assert.That(result, Is.EqualTo(false));              
        }                                                                                                                                                             
    }
}