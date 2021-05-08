﻿using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Items;

namespace Org.Ethasia.Adventuregrid.Core.Items.ItemsTests
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
            Shield shieldToEquip = new Shield();
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
            Shield shieldToEquip = new Shield();
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

            Equipment equippedMainHandEquipment = testCandidate.GetEquipmentInMainHand();
            Equipment equippedOffHandEquipment = testCandidate.GetEquipmentInOffHand();
            Equipment equippedHeadEquipment = testCandidate.GetEquipmentOnHead();
            Equipment equippedChestEquipment = testCandidate.GetEquipmentOnChest();
            Equipment equippedLegsEquipment = testCandidate.GetEquipmentOnLegs();
            Equipment equippedShoes = testCandidate.GetEquipmentOnFeet();
            Equipment equippedGloves = testCandidate.GetEquipmentOnHands();
            Equipment equippedLeftRing = testCandidate.GetEquipmentOnLeftRing();
            Equipment equippedRightRing = testCandidate.GetEquipmentOnRightRing();
            Equipment equippedAmulet = testCandidate.GetEquipmentOnAmulet();
 
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
    }
}