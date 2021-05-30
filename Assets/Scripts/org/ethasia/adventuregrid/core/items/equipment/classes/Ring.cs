namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Ring : EquipmentClass
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
            return true;
        }    

        public bool CanEquipOnLeftRingSlot()
        {
            return true;
        }  

        public bool CanEquipOnAmuletSlot()
        {
            return false;
        }                        
    }
}