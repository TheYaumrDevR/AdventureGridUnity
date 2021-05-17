using NUnit.Framework;
using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes;

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
            EquipmentClass bodyArmour = new BodyArmour();
            EquipmentClass pants = new Pants();
            EquipmentClass boots = new Boots();
            EquipmentClass gloves = new Gloves();

            EquipmentClass ring = new Ring();
            EquipmentClass amulet = new Amulet();
        }
    }
}