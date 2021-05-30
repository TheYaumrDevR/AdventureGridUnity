using NUnit.Framework;
using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes;
using Org.Ethasia.Adventuregrid.Core.Items.Equipment;

namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes.EquipmentClassesTests
{
    public class EquipmentClassesGeneralTest
    {
        [Test]
        public void TestThatAllEquipmentClassesExist()
        {   
            EquipmentClass oneHandedSword = new OneHandedSword();
            EquipmentClass twoHandedSword = new TwoHandedSword();

            EquipmentClass oneHandedMace = new OneHandedMace();
            EquipmentClass twoHandedMace = new TwoHandedMace();

            EquipmentClass bow = new Bow();
            EquipmentClass crossBow = new CrossBow();

            EquipmentClass wand = new Wand();
            EquipmentClass magicStaff = new MagicStaff();

            EquipmentClass shield = new Shield();
            EquipmentClass forceShield = new ForceShield();

            EquipmentClass arrowQuiver = new ArrowQuiver();
            EquipmentClass boltQuiver = new BoltQuiver();

            EquipmentClass helmet = new Helmet();
            EquipmentClass bodyArmor = new BodyArmor();
            EquipmentClass pants = new Pants();
            EquipmentClass shoes = new Shoes();
            EquipmentClass gloves = new Gloves();

            EquipmentClass ring = new Ring();
            EquipmentClass amulet = new Amulet();
        }

        [Test]
        public void TestThatOneHandedSwordCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedSword();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        }

        [Test]
        public void TestThatOneHandedMaceCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedMace();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        }     

        [Test]
        public void TestThatTwoHandedSwordCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new TwoHandedSword();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        }        

        [Test]
        public void TestThatTwoHandedMaceCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new TwoHandedMace();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        }         

        [Test]
        public void TestThatBowCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Bow();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        }   

        [Test]
        public void TestThatCrossbowCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new CrossBow();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        } 

        [Test]
        public void TestThatWandCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Wand();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        } 

        [Test]
        public void TestThatMagicStaffCanBeEquippedInMainHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new MagicStaff();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));
        }    

        [Test]
        public void TestThatOneHandedSwordsCanBeEquippedWithOneHandedWeaponsInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedSword();
            EquipmentClass offHandSword = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHandSword);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));

            testCandidate = new OneHandedSword();
            EquipmentClass offHandMace = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHandMace);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));    

            testCandidate = new OneHandedSword();
            EquipmentClass offHandWand = new Wand();

            playerEquipment.EquipInOffHand(offHandWand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                      
        }

        [Test]
        public void TestThatOneHandedMacesCanBeEquippedWithOneHandedWeaponsInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedMace();
            EquipmentClass offHandSword = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHandSword);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));

            testCandidate = new OneHandedMace();
            EquipmentClass offHandMace = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHandMace);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));    

            testCandidate = new OneHandedMace();
            EquipmentClass offHandWand = new Wand();

            playerEquipment.EquipInOffHand(offHandWand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                      
        }   

        [Test]
        public void TestThatWandsCanBeEquippedWithOneHandedWeaponsInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Wand();
            EquipmentClass offHandSword = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHandSword);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));

            testCandidate = new Wand();
            EquipmentClass offHandMace = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHandMace);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));    

            testCandidate = new Wand();
            EquipmentClass offHandWand = new Wand();

            playerEquipment.EquipInOffHand(offHandWand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                      
        } 

        [Test]
        public void TestThatOneHandedSwordsCanBeEquippedWithShieldsAndForceShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedSword();
            EquipmentClass shield = new Shield();

            playerEquipment.EquipInOffHand(shield);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));

            testCandidate = new OneHandedSword();
            EquipmentClass forceShield = new ForceShield();

            playerEquipment.EquipInOffHand(forceShield);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                         
        }  

        [Test]
        public void TestThatOneHandedMacesCanBeEquippedWithShieldsAndForceShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedMace();
            EquipmentClass shield = new Shield();

            playerEquipment.EquipInOffHand(shield);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));

            testCandidate = new OneHandedMace();
            EquipmentClass forceShield = new ForceShield();

            playerEquipment.EquipInOffHand(forceShield);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                         
        } 

        [Test]
        public void TestThatWandsCanBeEquippedWithShieldsAndForceShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Wand();
            EquipmentClass shield = new Shield();

            playerEquipment.EquipInOffHand(shield);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));

            testCandidate = new Wand();
            EquipmentClass forceShield = new ForceShield();

            playerEquipment.EquipInOffHand(forceShield);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                         
        }    

        [Test]
        public void TestThatOneHandedSwordsCannotBeEquippedWithQuivers()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedSword();
            EquipmentClass arrowQuiver = new ArrowQuiver();

            playerEquipment.EquipInOffHand(arrowQuiver);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new OneHandedSword();
            EquipmentClass boltQuiver = new BoltQuiver();

            playerEquipment.EquipInOffHand(boltQuiver);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                         
        }      

        [Test]
        public void TestThatOneHandedMacesCannotBeEquippedWithQuivers()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedMace();
            EquipmentClass arrowQuiver = new ArrowQuiver();

            playerEquipment.EquipInOffHand(arrowQuiver);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new OneHandedMace();
            EquipmentClass boltQuiver = new BoltQuiver();

            playerEquipment.EquipInOffHand(boltQuiver);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                         
        }     

        [Test]
        public void TestThatWandsCannotBeEquippedWithQuivers()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Wand();
            EquipmentClass arrowQuiver = new ArrowQuiver();

            playerEquipment.EquipInOffHand(arrowQuiver);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new Wand();
            EquipmentClass boltQuiver = new BoltQuiver();

            playerEquipment.EquipInOffHand(boltQuiver);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                         
        }   

        [Test]
        public void TestThatTwoHandedSwordsCannotBeEquippedWithOffHands()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new TwoHandedSword();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new TwoHandedSword();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new TwoHandedSword();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new TwoHandedSword();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new TwoHandedSword();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);     

            testCandidate = new TwoHandedSword();
            offHand = new ArrowQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);  

            testCandidate = new TwoHandedSword();
            offHand = new BoltQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                                                                    
        }      

        [Test]
        public void TestThatTwoHandedMacesCannotBeEquippedWithOffHands()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new TwoHandedMace();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new TwoHandedMace();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new TwoHandedMace();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new TwoHandedMace();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new TwoHandedMace();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);     

            testCandidate = new TwoHandedMace();
            offHand = new ArrowQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);  

            testCandidate = new TwoHandedMace();
            offHand = new BoltQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                                                                    
        }   

        [Test]
        public void TestThatMagicStaffsCannotBeEquippedWithOffHands()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new MagicStaff();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new MagicStaff();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new MagicStaff();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new MagicStaff();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new MagicStaff();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);     

            testCandidate = new MagicStaff();
            offHand = new ArrowQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);  

            testCandidate = new MagicStaff();
            offHand = new BoltQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                                                                    
        }     

        [Test]
        public void TestThatBowsCannotBeEquippedWithWeaponsOrShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Bow();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new Bow();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new Bow();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new Bow();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new Bow();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);     

            testCandidate = new Bow();
            offHand = new BoltQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);          

            testCandidate = new Bow();
            offHand = new ArrowQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                                                                         
        }     

        [Test]
        public void TestThatCrossBowsCannotBeEquippedWithWeaponsOrShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new CrossBow();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new CrossBow();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new CrossBow();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new CrossBow();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new CrossBow();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                                                                                 
        }                                                                            

        [Test]
        public void TestThatNonWeaponsCannotBeEquippedInMainHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();

            EquipmentClass amulet = new Amulet();
            EquipmentClass arrowQuiver = new ArrowQuiver();
            EquipmentClass bodyArmor = new BodyArmor();
            EquipmentClass boltQuiver = new BoltQuiver();
            EquipmentClass forceShield = new ForceShield();
            EquipmentClass gloves = new Gloves();
            EquipmentClass helmet = new Helmet();
            EquipmentClass pants = new Pants();
            EquipmentClass ring = new Ring();
            EquipmentClass shield = new Shield();
            EquipmentClass shoes = new Shoes();

            playerEquipment.EquipInMainHand(amulet);
            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(arrowQuiver);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(bodyArmor);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(boltQuiver);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(forceShield);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(gloves);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(helmet);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(pants);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(ring);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(shield);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(shoes);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);
        }    

        [Test]
        public void TestThatOneHandedSwordCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedSword();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }  

        [Test]
        public void TestThatOneHandedMaceCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedMace();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }            

        [Test]
        public void TestThatArrowQuiverCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new ArrowQuiver();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }    

        [Test]
        public void TestThatBoltQuiverCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new BoltQuiver();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }  

        [Test]
        public void TestThatShieldCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Shield();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }   

        [Test]
        public void TestThatForceShieldCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new ForceShield();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }   

        [Test]
        public void TestThatWandCanBeEquippedInOffHandWithNothingPresent()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Wand();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        }  

        [Test]
        public void TestThatOnlyOffHandsAndOneHandersCanBeEquippedInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();

            EquipmentClass amulet = new Amulet();
            EquipmentClass bodyArmor = new BodyArmor();
            EquipmentClass bow = new Bow();
            EquipmentClass crossBow = new CrossBow();
            EquipmentClass gloves = new Gloves();
            EquipmentClass helmet = new Helmet();
            EquipmentClass magicStaff = new MagicStaff();
            EquipmentClass pants = new Pants();
            EquipmentClass ring = new Ring();
            EquipmentClass shoes = new Shoes();
            EquipmentClass twoHandedMace = new TwoHandedMace();
            EquipmentClass twoHandedSword = new TwoHandedSword();

            playerEquipment.EquipInOffHand(amulet);
            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(bodyArmor);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(bow);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(crossBow);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);       

            playerEquipment.EquipInOffHand(gloves);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);   

            playerEquipment.EquipInOffHand(helmet);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);      

            playerEquipment.EquipInOffHand(magicStaff);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False); 

            playerEquipment.EquipInOffHand(pants);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);      

            playerEquipment.EquipInOffHand(ring);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);    

            playerEquipment.EquipInOffHand(shoes);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);  

            playerEquipment.EquipInOffHand(twoHandedMace);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);  

            playerEquipment.EquipInOffHand(twoHandedSword);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);                                                                                                             
        }   

        [Test]
        public void TestThatArrowQuiverCannotBeEquippedWhenNonBowIsInMainHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass mainHandEquipment = new OneHandedSword();

            EquipmentClass offHand = new ArrowQuiver();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);

            mainHandEquipment = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);         

            mainHandEquipment = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);        

            mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                   
        } 

        [Test]
        public void TestThatBoltQuiverCannotBeEquippedWhenNonCrossBowIsInMainHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass mainHandEquipment = new OneHandedSword();

            EquipmentClass offHand = new BoltQuiver();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);

            mainHandEquipment = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);         

            mainHandEquipment = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);        

            mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                   
        }  

        [Test]
        public void TestThatShieldsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass offHand = new Shield();       

            EquipmentClass mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));

            mainHandEquipment = new OneHandedMace();
            offHand = new Shield();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));       

            mainHandEquipment = new Wand();
            offHand = new Shield();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                         
        }

        [Test]
        public void TestThatForceShieldsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass offHand = new ForceShield();       

            EquipmentClass mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));

            mainHandEquipment = new OneHandedMace();
            offHand = new ForceShield();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));       

            mainHandEquipment = new Wand();
            offHand = new ForceShield();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                         
        }   

        [Test]
        public void TestThatOffhandOneHandedSwordsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass offHand = new OneHandedSword();       

            EquipmentClass mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));

            mainHandEquipment = new OneHandedMace();
            offHand = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));       

            mainHandEquipment = new Wand();
            offHand = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                         
        }  

        [Test]
        public void TestThatOffhandOneHandedMacesCanOnlyBeEquippedWithOneHandedWeapons()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass offHand = new OneHandedMace();       

            EquipmentClass mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));

            mainHandEquipment = new OneHandedMace();
            offHand = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));       

            mainHandEquipment = new Wand();
            offHand = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                         
        } 

        [Test]
        public void TestThatOffhandWandsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass offHand = new Wand();       

            EquipmentClass mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));

            mainHandEquipment = new OneHandedMace();
            offHand = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));       

            mainHandEquipment = new Wand();
            offHand = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                         
        } 

        [Test]
        public void TestThatOnlyHelmetsCanBeEquippedInHeadSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnHead(helmet);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnHead(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnHead(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnHead(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnHead(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnHead(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnHead(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnHead(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnHead(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnHead(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnHead(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnHead(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnHead(boltQuiver);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnHead(bodyArmor);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnHead(pants);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnHead(shoes);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnHead(gloves);

            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnHead(ring);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnHead(amulet);

            bool isHeadSlotOccupied = playerEquipment.IsHeadSlotOccupied();
            EquipmentClass headEquipment = playerEquipment.GetHeadEquipment();  
            Assert.That(isHeadSlotOccupied, Is.True);
            Assert.That(headEquipment, Is.EqualTo(helmet));          
        } 

        [Test]
        public void TestThatOnlyBodyArmorsCanBeEquippedInChestSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnChest(bodyArmor);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnChest(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnChest(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnChest(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnChest(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnChest(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnChest(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnChest(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnChest(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnChest(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnChest(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnChest(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnChest(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnChest(helmet);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnChest(pants);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnChest(shoes);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnChest(gloves);

            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnChest(ring);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnChest(amulet);

            bool isChestSlotOccupied = playerEquipment.IsChestSlotOccupied();
            EquipmentClass chestEquipment = playerEquipment.GetChestEquipment();  
            Assert.That(isChestSlotOccupied, Is.True);
            Assert.That(chestEquipment, Is.EqualTo(bodyArmor));          
        }  

        [Test]
        public void TestThatOnlyPantsCanBeEquippedInLegSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnLegs(pants);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnLegs(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnLegs(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnLegs(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnLegs(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnLegs(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnLegs(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnLegs(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnLegs(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnLegs(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnLegs(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnLegs(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnLegs(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnLegs(helmet);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnLegs(bodyArmor);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnLegs(shoes);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnLegs(gloves);

            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnLegs(ring);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnLegs(amulet);

            bool isLegSlotOccupied = playerEquipment.IsLegSlotOccupied();
            EquipmentClass legEquipment = playerEquipment.GetLegEquipment();  
            Assert.That(isLegSlotOccupied, Is.True);
            Assert.That(legEquipment, Is.EqualTo(pants));          
        }  

        [Test]
        public void TestThatOnlyShoesCanBeEquippedOnFeet()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnFeet(shoes);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnFeet(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnFeet(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnFeet(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnFeet(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnFeet(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnFeet(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnFeet(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnFeet(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnFeet(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnFeet(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnFeet(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnFeet(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnFeet(helmet);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnFeet(bodyArmor);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnFeet(pants);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnFeet(gloves);

            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnFeet(ring);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnFeet(amulet);

            bool isFeetSlotOccupied = playerEquipment.IsFeetSlotOccupied();
            EquipmentClass feetEquipment = playerEquipment.GetFeetEquipment();  
            Assert.That(isFeetSlotOccupied, Is.True);
            Assert.That(feetEquipment, Is.EqualTo(shoes));          
        } 

        [Test]
        public void TestThatOnlyGlovesCanBeEquippedOnHands()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnHands(gloves);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnHands(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnHands(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnHands(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnHands(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnHands(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnHands(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnHands(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnHands(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnHands(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnHands(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnHands(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnHands(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnHands(helmet);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnHands(bodyArmor);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnHands(pants);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnHands(shoes);

            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnHands(ring);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnHands(amulet);

            bool isHandsSlotOccupied = playerEquipment.IsHandsSlotOccupied();
            EquipmentClass handsEquipment = playerEquipment.GetHandsEquipment();  
            Assert.That(isHandsSlotOccupied, Is.True);
            Assert.That(handsEquipment, Is.EqualTo(gloves));          
        } 

        [Test]
        public void TestThatOnlyRingsCanBeEquippedOnRightRingSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnRightRingSlot(ring);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnRightRingSlot(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnRightRingSlot(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnRightRingSlot(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnRightRingSlot(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnRightRingSlot(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnRightRingSlot(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnRightRingSlot(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnRightRingSlot(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnRightRingSlot(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnRightRingSlot(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnRightRingSlot(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnRightRingSlot(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnRightRingSlot(helmet);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnRightRingSlot(bodyArmor);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnRightRingSlot(pants);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnRightRingSlot(shoes);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnRightRingSlot(gloves);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnRightRingSlot(amulet);

            bool isRightRingSlotOccupied = playerEquipment.IsRightRingSlotOccupied();
            EquipmentClass rightRingEquipment = playerEquipment.GetRightRingEquipment();  
            Assert.That(isRightRingSlotOccupied, Is.True);
            Assert.That(rightRingEquipment, Is.EqualTo(ring));          
        }  

        [Test]
        public void TestThatOnlyRingsCanBeEquippedOnLeftRingSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnLeftRingSlot(ring);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnLeftRingSlot(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnLeftRingSlot(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnLeftRingSlot(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnLeftRingSlot(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnLeftRingSlot(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnLeftRingSlot(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnLeftRingSlot(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnLeftRingSlot(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnLeftRingSlot(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnLeftRingSlot(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnLeftRingSlot(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnLeftRingSlot(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnLeftRingSlot(helmet);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnLeftRingSlot(bodyArmor);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnLeftRingSlot(pants);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnLeftRingSlot(shoes);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnLeftRingSlot(gloves);

            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnLeftRingSlot(amulet);

            bool isLeftRingSlotOccupied = playerEquipment.IsLeftRingSlotOccupied();
            EquipmentClass leftRingEquipment = playerEquipment.GetLeftRingEquipment();  
            Assert.That(isLeftRingSlotOccupied, Is.True);
            Assert.That(leftRingEquipment, Is.EqualTo(ring));          
        } 

        [Test]
        public void TestThatOnlyAmuletsCanBeEquippedOnAmuletSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            EquipmentClass amulet = new Amulet();
            playerEquipment.EquipOnAmuletSlot(amulet);

            EquipmentClass oneHandedSword = new OneHandedSword();
            playerEquipment.EquipOnAmuletSlot(oneHandedSword);

            EquipmentClass oneHandedMace = new OneHandedMace();
            playerEquipment.EquipOnAmuletSlot(oneHandedMace);

            EquipmentClass wand = new Wand();
            playerEquipment.EquipOnAmuletSlot(wand);
            
            EquipmentClass twoHandedSword = new TwoHandedSword();
            playerEquipment.EquipOnAmuletSlot(twoHandedSword);

            EquipmentClass twoHandedMace = new TwoHandedMace();
            playerEquipment.EquipOnAmuletSlot(twoHandedMace);

            EquipmentClass bow = new Bow();
            playerEquipment.EquipOnAmuletSlot(bow);

            EquipmentClass crossBow = new CrossBow();
            playerEquipment.EquipOnAmuletSlot(crossBow);

            EquipmentClass magicStaff = new MagicStaff();
            playerEquipment.EquipOnAmuletSlot(magicStaff);

            EquipmentClass shield = new Shield();
            playerEquipment.EquipOnAmuletSlot(shield);

            EquipmentClass forceShield = new ForceShield();
            playerEquipment.EquipOnAmuletSlot(forceShield);

            EquipmentClass arrowQuiver = new ArrowQuiver();
            playerEquipment.EquipOnAmuletSlot(arrowQuiver);

            EquipmentClass boltQuiver = new BoltQuiver();
            playerEquipment.EquipOnAmuletSlot(boltQuiver);

            EquipmentClass helmet = new Helmet();
            playerEquipment.EquipOnAmuletSlot(helmet);

            EquipmentClass bodyArmor = new BodyArmor();
            playerEquipment.EquipOnAmuletSlot(bodyArmor);

            EquipmentClass pants = new Pants();
            playerEquipment.EquipOnAmuletSlot(pants);

            EquipmentClass shoes = new Shoes();
            playerEquipment.EquipOnAmuletSlot(shoes);

            EquipmentClass gloves = new Gloves();
            playerEquipment.EquipOnAmuletSlot(gloves);

            EquipmentClass ring = new Ring();
            playerEquipment.EquipOnAmuletSlot(ring);

            bool isAmuletSlotOccupied = playerEquipment.IsAmuletSlotOccupied();
            EquipmentClass amuletEquipment = playerEquipment.GetAmuletEquipment();  
            Assert.That(isAmuletSlotOccupied, Is.True);
            Assert.That(amuletEquipment, Is.EqualTo(amulet));          
        }                                                                                      
    }
}