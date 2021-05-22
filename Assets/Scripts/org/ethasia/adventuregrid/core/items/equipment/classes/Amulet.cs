namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Amulet : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }        
    }
}