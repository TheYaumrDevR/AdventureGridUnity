using NUnit.Framework;
using System.Collections;

using Org.Ethasia.Adventuregrid.Core.Math;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Tests
{
    public class IslandTest
    {
        [Test]
        public void BlockAtUninitializedPositionIsAir() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(63, 0, 63);
        
            Block blockAt = testCandidate.GetBlockAt(blockPosition);
        
            Assert.That(blockAt.GetBlockType(), Is.EqualTo(BlockTypes.AIR));      
        }

        [Test]
        public void RetrievesPreviouslyPlacedBlock() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = GrassyEarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(63, 0, 63);
        
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            Block blockAt = testCandidate.GetBlockAt(blockPosition);         

            Assert.That(blockAt, Is.SameAs(testBlock));
        }  

        [Test]
        public void CanPlaceBlockAtMaximumHeight() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = EarthBlock.GetInstance(); 
            BlockPosition blockPosition = new BlockPosition(63, 255, 63);
        
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            Block blockAt = testCandidate.GetBlockAt(blockPosition);      

            Assert.That(blockAt, Is.SameAs(testBlock));
        }   

        [Test]
        public void CannotPlaceBlockAboveMaximumHeight() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = RockBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(63, 256, 63);

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, blockPosition));            
        } 

        [Test]
        public void CannotPlaceBlockOutsideXDimension() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = GrassyEarthBlock.GetInstance();  
            BlockPosition blockPosition = new BlockPosition(64, 200, 24);

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, blockPosition));                
        } 

        [Test]
        public void CannotPlaceBlockOutsideZDimension() 
        {
            Island testCandidate = new Island(64);
            Block testBlock = EarthBlock.GetInstance();
            BlockPosition blockPosition = new BlockPosition(54, 13, 64);

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.PlaceBlockAt(testBlock, blockPosition));                
        }  

        [Test]
        public void CannotGetBlockAboveMaxHeight() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(63, 256, 63);

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(blockPosition)); 
        }      

        [Test]
        public void CannotGetBlockOutsideXDimension() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(64, 123, 52);

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(blockPosition)); 
        }  

        [Test]
        public void CannotGetBlockOutsideZDimension() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(32, 222, 64);

            Assert.Throws<BlockPositionOutOfBoundsException>(() => testCandidate.GetBlockAt(blockPosition)); 
        }  

        [Test]
        public void IslandHasCorrectXzDimension() 
        {
            Island testCandidate = new Island(48);
        
            int result = testCandidate.GetXzDimension();
        
            Assert.That(result, Is.EqualTo(48));
        } 

        [Test]
        public void LeftFaceOfRockBlockIsHiddenWhenCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(4, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(5, 0, 0);
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPositionOne);

            Assert.That(result, Is.EqualTo(true));
        } 

        [Test]
        public void LeftFaceOfRockBlockIsVisibleWhenNotCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(4, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(5, 0, 0);            
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPositionOne);

            Assert.That(result, Is.EqualTo(false)); 
        } 

        [Test]
        public void BlockFaceIsVisibleWhenItsNotCovering() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(4, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(5, 0, 0);              
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPositionOne);

            Assert.That(result, Is.EqualTo(false)); 
        }    

        [Test]
        public void LeftBlockFaceIsVisibleWhenOnLeftIslandEdge() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(63, 0, 0);
        
            Block testBlock = RockBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.LEFT, blockPosition);

            Assert.That(result, Is.EqualTo(false));             
        }

        [Test]
        public void FrontFaceOfEarthBlockIsHiddenWhenCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 7);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 8);              
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, blockPositionOne);

            Assert.That(result, Is.EqualTo(true));
        } 

        [Test]
        public void FrontFaceOfEarthBlockIsVisibleWhenNotCovered() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 7);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 8);              
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));            
        } 

        [Test]
        public void FrontFaceOfBlockIsVisibleWhenNotCovering() 
        {
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 7);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 8);             
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT,blockPositionOne);

            Assert.That(result, Is.EqualTo(false)); 
        }  

        [Test]
        public void FrontFaceOfBlockIsVisibleWhenAtFrontEdgeOfIsland() 
        {              
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 63);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.FRONT, blockPosition);

            Assert.That(result, Is.EqualTo(false)); 
        }

        [Test]
        public void RightFaceOfBlockIsHiddenWhenCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(46, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(45, 0, 0);              
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPositionOne);

            Assert.That(result, Is.EqualTo(true)); 
        }  

        [Test]
        public void RightFaceOfBlockIsVisibleWhenNotCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(46, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(45, 0, 0);               
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));             
        } 

        [Test]
        public void RightFaceOfBlockIsVisibleWhenNotFullyCovering() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(46, 0, 0);
            BlockPosition blockPositionTwo = new BlockPosition(45, 0, 0);             
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));               
        } 

        [Test]
        public void RightFaceOfBlockIsVisibleWhenAtRightEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 0);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.RIGHT, blockPosition);

            Assert.That(result, Is.EqualTo(false));              
        }    

        [Test]
        public void BackFaceOfBlockIsHiddenWhenCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 24);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 23);              
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPositionOne);

            Assert.That(result, Is.EqualTo(true));               
        }   

        [Test]
        public void BackFaceOfBlockIsVisibleWhenNotCovered() 
        {  
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 24);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 23);               
        
            Block testBlock = RockBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));              
        }

        [Test]
        public void BackFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 0, 24);
            BlockPosition blockPositionTwo = new BlockPosition(0, 0, 23);           

            Block testBlock = AirBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));            
        }  

        [Test]
        public void BackFaceOfBlockIsVisibleWhenAtBackEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 0);
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BACK, blockPosition);

            Assert.That(result, Is.EqualTo(false));             
        } 

        [Test]
        public void BottomFaceOfBlockIsHiddenWhenCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);              
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = EarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock,blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, blockPositionOne);

            Assert.That(result, Is.EqualTo(true));             
        }  

        [Test]
        public void BottomFaceOfBlockIsVisibleWhenNotCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);             
        
            Block testBlock = EarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, blockPositionOne);   

            Assert.That(result, Is.EqualTo(false));                     
        }    

        [Test]
        public void BottomFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);                 
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));             
        }          

        [Test]
        public void BottomFaceOfBlockIsVisibleWhenAtBottomEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 0, 0);            
        
            Block testBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.BOTTOM,blockPosition);

            Assert.That(result, Is.EqualTo(false));             
        } 

        [Test]
        public void TopFaceOfBlockIsHiddenWhenCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 5, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 4, 0);              
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = GrassyEarthBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock,blockPositionTwo);
            testCandidate.PlaceBlockAt(neighbor, blockPositionOne);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPositionTwo);

            Assert.That(result, Is.EqualTo(true));            
        }  

        [Test]
        public void TopFaceOfBlockIsVisibleWhenNotCovered() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 4, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 5, 0);                
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            Block neighbor = AirBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock, blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));            
        } 

        [Test]
        public void TopFaceOfBlockIsVisibleWhenNotFullyCovering() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPositionOne = new BlockPosition(0, 4, 0);
            BlockPosition blockPositionTwo = new BlockPosition(0, 5, 0);              
        
            Block testBlock = AirBlock.GetInstance();
            Block neighbor = RockBlock.GetInstance();
        
            testCandidate.PlaceBlockAt(testBlock,blockPositionOne);
            testCandidate.PlaceBlockAt(neighbor, blockPositionTwo);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPositionOne);

            Assert.That(result, Is.EqualTo(false));             
        }  

        [Test]
        public void TopFaceOfBlockIsVisibleWhenAtTopEdgeOfIsland() 
        { 
            Island testCandidate = new Island(64);
            BlockPosition blockPosition = new BlockPosition(0, 255, 0);
        
            Block testBlock = GrassyEarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(testBlock, blockPosition);
        
            bool result = testCandidate.BlockFaceAtPositionIsHidden(BlockFaceDirections.TOP, blockPosition);

            Assert.That(result, Is.EqualTo(false));              
        }    

        [Test]
        public void TestThatIslandsSealedForEditingCannotBeEdited()
        {
            Island testCandidate = new Island(8);
            BlockPosition placementPosition = new BlockPosition(3, 45, 2);

            Block placedBlock = EarthBlock.GetInstance();
            testCandidate.PlaceBlockAt(placedBlock, placementPosition);

            Block expectedBlock = testCandidate.GetBlockAt(placementPosition);

            testCandidate.SealForPlayerEditing();
            placementPosition = new BlockPosition(4, 11, 2);
            testCandidate.PlaceBlockAt(placedBlock, placementPosition);

            Block expectedBlockTwo = testCandidate.GetBlockAt(placementPosition);

            Assert.That(expectedBlock, Is.SameAs(placedBlock));
            Assert.That(expectedBlockTwo, Is.SameAs(AirBlock.GetInstance()));
        }               

        [Test]
        public void TestBlockAtPositionIsWalkableReturnsTrueForEarthBlock()
        {
            Island testCandidate = new Island(3);

            BlockPosition placementPosition = new BlockPosition(1, 1, 1);
            Block placedBlock = EarthBlock.GetInstance();

            testCandidate.PlaceBlockAt(placedBlock, placementPosition);

            Assert.That(testCandidate.BlockAtPositionIsWalkable(placementPosition), Is.EqualTo(true));
        }

        [Test]
        public void TestBlockAtPositionIsWalkableReturnsFalseForPortalBlock()
        {
            Island testCandidate = new Island(3);

            BlockPosition placementPosition = new BlockPosition(1, 1, 1);
            Block placedBlock = PortalBlock.GetInstance();

            testCandidate.PlaceBlockAt(placedBlock, placementPosition);

            Assert.That(testCandidate.BlockAtPositionIsWalkable(placementPosition), Is.EqualTo(false));
        }                                                                                                                                     
    }
}