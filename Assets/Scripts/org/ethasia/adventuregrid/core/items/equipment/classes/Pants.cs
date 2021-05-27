namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Pants : EquipmentClass
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
            return true;
        }    

        public bool CanEquipOnFeet()
        {
            return false;
        }   

        public bool CanEquipOnHands()
        {
            return false;
        }       

        public bool CanEquipOnRightRing()
        {
            return false;
        }                              
    }
}