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
    }
}