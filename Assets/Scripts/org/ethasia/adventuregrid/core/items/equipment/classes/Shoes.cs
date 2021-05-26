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

        public bool CanEquipOnHead()
        {
            return false;
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