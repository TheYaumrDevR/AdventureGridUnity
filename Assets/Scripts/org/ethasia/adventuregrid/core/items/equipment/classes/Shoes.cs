namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Shoes : EquipmentClass
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