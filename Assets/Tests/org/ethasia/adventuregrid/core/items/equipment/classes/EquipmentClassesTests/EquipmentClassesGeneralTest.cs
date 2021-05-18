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
    }
}