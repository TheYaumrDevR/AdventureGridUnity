using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Slottypes;

namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Slottypes.EquipmentSlotTypesTests
{

    [TestFixture]
    public class PlayerEquipmentSlotsTest
    {

        [Test]
        public void TestThatNewPlayerEquipmentHasEmptySlots()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            bool isMainHandSlotEmpty = testCandidate.IsMainHandSlotEmpty();
            bool isOffHandSlotEmpty = testCandidate.IsOffHandSlotEmpty();
            bool isHeadSlotEmpty = testCandidate.IsHeadSlotEmpty();
            bool isChestSlotEmpty = testCandidate.IsChestSlotEmpty();
            bool isLegSlotEmpty = testCandidate.IsLegSlotEmpty();
            bool isFeetSlotEmpty = testCandidate.IsFeetSlotEmpty();
            bool isHandSlotEmpty = testCandidate.IsHandSlotEmpty();
            bool isLeftRingSlotEmpty = testCandidate.IsLeftRingSlotEmpty();
            bool isRightRingSlotEmpty = testCandidate.IsRightRingSlotEmpty();
            bool isAmuletSlotEmpty = testCandidate.IsAmuletSlotEmpty();

            Assert.That(isMainHandSlotEmpty, Is.True);
            Assert.That(isOffHandSlotEmpty, Is.True);
            Assert.That(isHeadSlotEmpty, Is.True);
            Assert.That(isChestSlotEmpty, Is.True);
            Assert.That(isLegSlotEmpty, Is.True);
            Assert.That(isFeetSlotEmpty, Is.True);
            Assert.That(isFeetSlotEmpty, Is.True);
            Assert.That(isHandSlotEmpty, Is.True);
            Assert.That(isLeftRingSlotEmpty, Is.True);
            Assert.That(isRightRingSlotEmpty, Is.True);
            Assert.That(isAmuletSlotEmpty, Is.True);
        }

        [Test]
        public void TestThatEquippingEquipmentOccupiesTheSlot()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            TwoHandedWeapon weaponToEquip = new TwoHandedWeapon();
            OffHand shieldToEquip = new OffHand();
            Helmet helmetToEquip = new Helmet();
            BodyArmor bodyArmorToEquip = new BodyArmor();
            Pants pantsToEquip = new Pants();
            Shoes bootsToEquip = new Shoes();
            Gloves glovesToEquip = new Gloves();
            Ring leftRingToEquip = new Ring();
            Ring rightRingToEquip = new Ring();
            Amulet amuletToEquip = new Amulet();

            testCandidate.EquipInMainHand(weaponToEquip);
            testCandidate.EquipInOffHand(shieldToEquip);
            testCandidate.EquipInHead(helmetToEquip);
            testCandidate.EquipInChest(bodyArmorToEquip);
            testCandidate.EquipInLegs(pantsToEquip);
            testCandidate.EquipInFeet(bootsToEquip);
            testCandidate.EquipInHands(glovesToEquip);
            testCandidate.EquipInLeftRing(leftRingToEquip);
            testCandidate.EquipInRightRing(rightRingToEquip);
            testCandidate.EquipInAmulet(amuletToEquip);

            bool isMainHandSlotEmpty = testCandidate.IsMainHandSlotEmpty();
            bool isOffHandSlotEmpty = testCandidate.IsOffHandSlotEmpty();
            bool isHeadSlotEmpty = testCandidate.IsHeadSlotEmpty();
            bool isChestSlotEmpty = testCandidate.IsChestSlotEmpty();
            bool isLegSlotEmpty = testCandidate.IsLegSlotEmpty();
            bool isFeetSlotEmpty = testCandidate.IsFeetSlotEmpty();
            bool isHandSlotEmpty = testCandidate.IsHandSlotEmpty();
            bool isLeftRingSlotEmpty = testCandidate.IsLeftRingSlotEmpty();
            bool isRightRingSlotEmpty = testCandidate.IsRightRingSlotEmpty();
            bool isAmuletSlotEmpty = testCandidate.IsAmuletSlotEmpty();

            Assert.That(isMainHandSlotEmpty, Is.False);
            Assert.That(isOffHandSlotEmpty, Is.False);
            Assert.That(isHeadSlotEmpty, Is.False);
            Assert.That(isChestSlotEmpty, Is.False);
            Assert.That(isLegSlotEmpty, Is.False);
            Assert.That(isFeetSlotEmpty, Is.False);
            Assert.That(isHandSlotEmpty, Is.False);
            Assert.That(isLeftRingSlotEmpty, Is.False);
            Assert.That(isRightRingSlotEmpty, Is.False);
            Assert.That(isAmuletSlotEmpty, Is.False);
        }

        [Test]
        public void TestThatEquippingEquipmentPutsTheEquipmnentIntoTheSlot()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            OneHandedWeapon weaponToEquip = new OneHandedWeapon();
            OffHand shieldToEquip = new OffHand();
            Helmet helmetToEquip = new Helmet();
            BodyArmor bodyArmorToEquip = new BodyArmor();
            Pants pantsToEquip = new Pants();
            Shoes bootsToEquip = new Shoes();
            Gloves glovesToEquip = new Gloves();
            Ring leftRingToEquip = new Ring();
            Ring rightRingToEquip = new Ring();
            Amulet amuletToEquip = new Amulet();

            testCandidate.EquipInMainHand(weaponToEquip);
            testCandidate.EquipInOffHand(shieldToEquip);
            testCandidate.EquipInHead(helmetToEquip);
            testCandidate.EquipInChest(bodyArmorToEquip);
            testCandidate.EquipInLegs(pantsToEquip);
            testCandidate.EquipInFeet(bootsToEquip);
            testCandidate.EquipInHands(glovesToEquip);
            testCandidate.EquipInLeftRing(leftRingToEquip);
            testCandidate.EquipInRightRing(rightRingToEquip);
            testCandidate.EquipInAmulet(amuletToEquip);

            EquipmentSlotType equippedMainHandEquipment = testCandidate.GetEquipmentInMainHand();
            EquipmentSlotType equippedOffHandEquipment = testCandidate.GetEquipmentInOffHand();
            EquipmentSlotType equippedHeadEquipment = testCandidate.GetEquipmentOnHead();
            EquipmentSlotType equippedChestEquipment = testCandidate.GetEquipmentOnChest();
            EquipmentSlotType equippedLegsEquipment = testCandidate.GetEquipmentOnLegs();
            EquipmentSlotType equippedShoes = testCandidate.GetEquipmentOnFeet();
            EquipmentSlotType equippedGloves = testCandidate.GetEquipmentOnHands();
            EquipmentSlotType equippedLeftRing = testCandidate.GetEquipmentOnLeftRing();
            EquipmentSlotType equippedRightRing = testCandidate.GetEquipmentOnRightRing();
            EquipmentSlotType equippedAmulet = testCandidate.GetEquipmentOnAmulet();
 
            Assert.That(weaponToEquip, Is.EqualTo(equippedMainHandEquipment));
            Assert.That(shieldToEquip, Is.EqualTo(equippedOffHandEquipment));
            Assert.That(helmetToEquip, Is.EqualTo(equippedHeadEquipment));
            Assert.That(bodyArmorToEquip, Is.EqualTo(equippedChestEquipment));
            Assert.That(pantsToEquip, Is.EqualTo(equippedLegsEquipment));
            Assert.That(bootsToEquip, Is.EqualTo(equippedShoes));
            Assert.That(glovesToEquip, Is.EqualTo(equippedGloves));
            Assert.That(leftRingToEquip, Is.EqualTo(equippedLeftRing));
            Assert.That(rightRingToEquip, Is.EqualTo(equippedRightRing));
            Assert.That(amuletToEquip, Is.EqualTo(equippedAmulet));
        }

        [Test]
        public void TestThatOneHandedWeaponsCanOnlyBeEquippedInOneHandedWeaponSlots()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();
            OneHandedWeapon leftSword = new OneHandedWeapon();
            OneHandedWeapon rightSword = new OneHandedWeapon();

            testCandidate.EquipInMainHand(leftSword);
            testCandidate.EquipInOffHand(rightSword);  
            testCandidate.EquipInHead(leftSword);
            testCandidate.EquipInChest(leftSword);
            testCandidate.EquipInLegs(leftSword);
            testCandidate.EquipInFeet(leftSword);
            testCandidate.EquipInHands(rightSword);
            testCandidate.EquipInLeftRing(rightSword);
            testCandidate.EquipInRightRing(rightSword);
            testCandidate.EquipInAmulet(rightSword); 

            EquipmentSlotType equippedMainHandEquipment = testCandidate.GetEquipmentInMainHand();
            EquipmentSlotType equippedOffHandEquipment = testCandidate.GetEquipmentInOffHand();
            EquipmentSlotType equippedHeadEquipment = testCandidate.GetEquipmentOnHead();
            EquipmentSlotType equippedChestEquipment = testCandidate.GetEquipmentOnChest();
            EquipmentSlotType equippedLegsEquipment = testCandidate.GetEquipmentOnLegs();
            EquipmentSlotType equippedShoes = testCandidate.GetEquipmentOnFeet();
            EquipmentSlotType equippedGloves = testCandidate.GetEquipmentOnHands();
            EquipmentSlotType equippedLeftRing = testCandidate.GetEquipmentOnLeftRing();
            EquipmentSlotType equippedRightRing = testCandidate.GetEquipmentOnRightRing();
            EquipmentSlotType equippedAmulet = testCandidate.GetEquipmentOnAmulet();     

            Assert.That(leftSword, Is.EqualTo(equippedMainHandEquipment));
            Assert.That(rightSword, Is.EqualTo(equippedOffHandEquipment));

            Assert.That(leftSword, Is.Not.EqualTo(equippedHeadEquipment));
            Assert.That(leftSword, Is.Not.EqualTo(equippedChestEquipment));
            Assert.That(leftSword, Is.Not.EqualTo(equippedLegsEquipment));
            Assert.That(leftSword, Is.Not.EqualTo(equippedShoes));
            Assert.That(leftSword, Is.Not.EqualTo(equippedGloves));
            Assert.That(leftSword, Is.Not.EqualTo(equippedLeftRing));
            Assert.That(leftSword, Is.Not.EqualTo(equippedRightRing));
            Assert.That(leftSword, Is.Not.EqualTo(equippedAmulet));      

            Assert.That(rightSword, Is.Not.EqualTo(equippedHeadEquipment));
            Assert.That(rightSword, Is.Not.EqualTo(equippedChestEquipment));
            Assert.That(rightSword, Is.Not.EqualTo(equippedLegsEquipment));
            Assert.That(rightSword, Is.Not.EqualTo(equippedShoes));
            Assert.That(rightSword, Is.Not.EqualTo(equippedGloves));
            Assert.That(rightSword, Is.Not.EqualTo(equippedLeftRing));
            Assert.That(rightSword, Is.Not.EqualTo(equippedRightRing));
            Assert.That(rightSword, Is.Not.EqualTo(equippedAmulet));                                               
        }

        [Test]
        public void TestThatMainHandSlotOnlyAllowsWeapons()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            Helmet helmetToEquip = new Helmet();

            testCandidate.EquipInHead(helmetToEquip);
            testCandidate.EquipInMainHand(helmetToEquip);

            EquipmentSlotType equippedHeadEquipment = testCandidate.GetEquipmentOnHead();
            EquipmentSlotType equippedMainHandEquipment = testCandidate.GetEquipmentInMainHand();

            Assert.That(helmetToEquip, Is.EqualTo(equippedHeadEquipment));
            Assert.That(helmetToEquip, Is.Not.EqualTo(equippedMainHandEquipment));
        }

        [Test]
        public void TestThatOffHandSlotOnlyAllowsOffHandEquipment()
        {
            PlayerEquipmentSlots testCandidate = new PlayerEquipmentSlots();

            BodyArmor bodyArmorToEquip = new BodyArmor();

            testCandidate.EquipInChest(bodyArmorToEquip);
            testCandidate.EquipInOffHand(bodyArmorToEquip);

            EquipmentSlotType equippedChestEquipment = testCandidate.GetEquipmentOnChest();
            EquipmentSlotType equippedOffHandEquipment = testCandidate.GetEquipmentInOffHand();

            Assert.That(bodyArmorToEquip, Is.EqualTo(equippedChestEquipment));
            Assert.That(bodyArmorToEquip, Is.Not.EqualTo(equippedOffHandEquipment));
        }        
    }
}