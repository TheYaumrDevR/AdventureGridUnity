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

        public bool CanEquipOnFeet()
        {
            return false;
        }   

        public bool CanEquipOnHands()
        {
            return false;
        }  

        public bool CanEquipOnRightRingSlot()
        {
            return false;
        }

        public bool CanEquipOnLeftRingSlot()
        {
            return false;
        } 

        public bool CanEquipOnAmuletSlot()
        {
            return false;
        }                                         
    }
}