using NUnit.Framework;

using Org.Ethasia.Adventuregrid.Core.Items;

namespace Org.Ethasia.Adventuregrid.Core.Items.ItemsTests
{

    [TestFixture]
    public class PlayerEquipmentTest
    {

        [Test]
        public void TestThatNewPlayerEquipmentHasEmptySlots()
        {
            PlayerEquipment testCandidate = new PlayerEquipment();

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
    }
}