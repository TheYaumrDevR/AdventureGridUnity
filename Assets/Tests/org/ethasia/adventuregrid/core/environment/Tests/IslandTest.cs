using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class IslandTest
    {
        [UnityTest]
        public IEnumerator BlockAtUninitializedPositionIsAir() 
        {
            Island testCandidate = new Island(64);
        
            Block blockAt = testCandidate.GetBlockAt(63, 0, 63);
        
            yield return null;

            Assert.That(blockAt.GetBlockType(), Is.EqualTo(BlockTypes.AIR));      
        }

        [UnityTest]
        public IEnumerator RetrievesPreviouslyPlacedBlock() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 63, 0, 63);
        
            Block blockAt = testCandidate.GetBlockAt(63, 0, 63);         

            yield return null;     

            Assert.That(blockAt, Is.SameAs(testBlock));
        }  

        [UnityTest]
        public IEnumerator CanPlaceBlockAtMaximumHeight() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = EarthBlock.GetInstance(); 
        
            testCandidate.PlaceBlockAt(testBlock, 63, 255, 63);
        
            Block blockAt = testCandidate.GetBlockAt(63, 255, 63);      

            yield return null; 

            Assert.That(blockAt, Is.SameAs(testBlock));
        }   

        [UnityTest]
        public IEnumerator CannotPlaceBlockAboveMaximumHeight() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = RockBlock.GetInstance();

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, 63, 256, 63));            
        } 

        [UnityTest]
        public IEnumerator CannotPlaceBlockOutsideXDimension() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = GrassyEarthBlock.GetInstance();  

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, 64, 200, 24));                
        } 

        [UnityTest]
        public IEnumerator CannotPlaceBlockOutsideZDimension() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = EarthBlock.GetInstance();

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, 54, 13, 64));                
        }  

        [UnityTest]
        public IEnumerator CannotGetBlockAboveMaxHeight() 
        {
            Island testCandidate = new Island(64);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(63, 256, 63)); 
        }      

        [UnityTest]
        public IEnumerator CannotGetBlockOutsideXDimension() 
        {
            Island testCandidate = new Island(64);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(64, 123, 52)); 
        }  

        [UnityTest]
        public IEnumerator CannotGetBlockOutsideZDimension() 
        {
            Island testCandidate = new Island(64);

            yield return null; 

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(32, 222, 64)); 
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
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 5, 0, 0);
            testCandidate.PlaceBlockAt(neighbor, 4, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, 5, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(true));
        } 

        [UnityTest]
        public IEnumerator LeftFaceOfRockBlockIsVisibleWhenNotCovered() 
        {
            Island testCandidate = new Island(64);
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 5, 0, 0);
            testCandidate.PlaceBlockAt(neighbor, 4, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, 5, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        } 

        [UnityTest]
        public IEnumerator BlockFaceIsVisibleWhenItsNotCovering() 
        {
            Island testCandidate = new Island(64);
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 5, 0, 0);
            testCandidate.PlaceBlockAt(neighbor, 4, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, 5, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        }    

        [UnityTest]
        public IEnumerator LeftBlockFaceIsVisibleWhenOnLeftIslandEdge() 
        {
            Island testCandidate = new Island(64);
        
            Block testBlock = RockBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, 0, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        }

        [UnityTest]
        public IEnumerator FrontFaceOfEarthBlockIsHiddenWhenCovered() 
        {
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 7);
            testCandidate.PlaceBlockAt(neighbor, 0, 0, 8);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, 0, 0, 7);

            yield return null;

            Assert.That(result, Is.EqualTo(true));
        } 

        [UnityTest]
        public IEnumerator FrontFaceOfEarthBlockIsVisibleWhenNotCovered() 
        {
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 7);
            testCandidate.PlaceBlockAt(neighbor, 0, 0, 8);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, 0, 0, 7);

            yield return null;

            Assert.That(result, Is.EqualTo(false));            
        } 

        [UnityTest]
        public IEnumerator FrontFaceOfBlockIsVisibleWhenNotCovering() 
        {
            Island testCandidate = new Island(64);
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 7);
            testCandidate.PlaceBlockAt(neighbor, 0, 0, 8);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, 0, 0, 7);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        }  

        [UnityTest]
        public IEnumerator FrontFaceOfBlockIsVisibleWhenAtFrontEdgeOfIsland() 
        {              
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 63);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, 0, 0, 63);

            yield return null;

            Assert.That(result, Is.EqualTo(false)); 
        }

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsHiddenWhenCovered() 
        {  
            Island testCandidate = new Island(64);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 45, 0, 0);
            testCandidate.PlaceBlockAt(neighbor, 46, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, 45, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(true)); 
        }  

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsVisibleWhenNotCovered() 
        {  
            Island testCandidate = new Island(64);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 45, 0, 0);
            testCandidate.PlaceBlockAt(neighbor, 46, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, 45, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        } 

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsVisibleWhenNotFullyCovering() 
        {  
            Island testCandidate = new Island(64);
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 45, 0, 0);
            testCandidate.PlaceBlockAt(neighbor, 46, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, 45, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));               
        } 

        [UnityTest]
        public IEnumerator RightFaceOfBlockIsVisibleWhenAtRightEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, 63, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, 63, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));              
        }    

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsHiddenWhenCovered() 
        {  
            Island testCandidate = new Island(64);
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 24);
            testCandidate.PlaceBlockAt(neighbor, 0, 0, 23);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, 0, 0, 24);

            yield return null;

            Assert.That(result, Is.EqualTo(true));               
        }   

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsVisibleWhenNotCovered() 
        {  
            Island testCandidate = new Island(64);
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 24);
            testCandidate.PlaceBlockAt(neighbor, 0, 0, 23);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, 0, 0, 24);

            yield return null;

            Assert.That(result, Is.EqualTo(false));              
        }

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 24);
            testCandidate.PlaceBlockAt(neighbor, 0, 0, 23);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, 0, 0, 24);

            yield return null;

            Assert.That(result, Is.EqualTo(false));            
        }  

        [UnityTest]
        public IEnumerator BackFaceOfBlockIsVisibleWhenAtBackEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, 0, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        } 

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsHiddenWhenCovered() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 5, 0);
            testCandidate.PlaceBlockAt(neighbor, 0, 4, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, 0, 5, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(true));             
        }  

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsVisibleWhenNotCovered() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 5, 0);
            testCandidate.PlaceBlockAt(neighbor, 0, 4, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, 0, 5, 0);   

            yield return null;

            Assert.That(result, Is.EqualTo(false));                     
        }    

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 5, 0);
            testCandidate.PlaceBlockAt(neighbor, 0, 4, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, 0, 5, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        }          

        [UnityTest]
        public IEnumerator BottomFaceOfBlockIsVisibleWhenAtBottomEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, 0, 0, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, 0, 0, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        } 

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsHiddenWhenCovered() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 4, 0);
            testCandidate.PlaceBlockAt(neighbor, 0, 5, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, 0, 4, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(true));            
        }  

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsVisibleWhenNotCovered() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 4, 0);
            testCandidate.PlaceBlockAt(neighbor, 0, 5, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, 0, 4, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));            
        } 

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, 0, 4, 0);
            testCandidate.PlaceBlockAt(neighbor, 0, 5, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, 0, 4, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));             
        }  

        [UnityTest]
        public IEnumerator TopFaceOfBlockIsVisibleWhenAtTopEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, 0, 255, 0);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, 0, 255, 0);

            yield return null;

            Assert.That(result, Is.EqualTo(false));              
        }                                                                                                                                                             
    }
}