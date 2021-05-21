namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public interface EquipmentClass
    {
        bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments);
        bool CanEquipInOffHand();
    }
}