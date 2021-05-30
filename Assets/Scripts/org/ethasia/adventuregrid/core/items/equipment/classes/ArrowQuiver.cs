namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class ArrowQuiver : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }     

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass mainHandEquipment = otherEquipments.GetMainHandEquipment();

            if (!(null == mainHandEquipment || mainHandEquipment is Bow))
            {
                return false;
            }

            return true;
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