namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Ring : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }   

        public bool CanEquipInOffHand()
        {
            return false;
        }                
    }
}