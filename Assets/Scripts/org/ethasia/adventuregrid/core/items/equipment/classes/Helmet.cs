namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Helmet : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }    

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }  

        public bool CanEquipOnHead()
        {
            return true;
        } 

        public bool CanEquipOnChest()
        {
            return false;
        }   

        public bool CanEquipOnLegs()
        {
            return false;
        }                                     
    }
}