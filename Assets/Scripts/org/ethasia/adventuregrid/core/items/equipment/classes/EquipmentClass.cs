namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public interface EquipmentClass
    {
        bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments);
        bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments);
        bool CanEquipOnHead();
        bool CanEquipOnChest();
        bool CanEquipOnLegs();
        bool CanEquipOnFeet();
        bool CanEquipOnHands();
        bool CanEquipOnRightRing();
    }
}