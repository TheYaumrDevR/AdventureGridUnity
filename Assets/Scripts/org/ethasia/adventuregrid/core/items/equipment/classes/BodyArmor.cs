namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class BodyArmor : EquipmentClass
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
            return true;
        }  

        public bool CanEquipOnLegs()
        {
            return false;
        }                                 
    }
}