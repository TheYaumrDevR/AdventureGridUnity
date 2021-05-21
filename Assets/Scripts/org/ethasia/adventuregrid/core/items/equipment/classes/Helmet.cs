namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Helmet : EquipmentClass
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