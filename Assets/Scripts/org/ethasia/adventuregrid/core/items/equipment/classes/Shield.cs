namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Shield : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }   

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass mainHandEquipment = otherEquipments.GetMainHandEquipment();

            if (null == mainHandEquipment || EquipmentIsOneHandedWeapon(mainHandEquipment))
            {
                return true;
            }

            return false;
        }      

        private bool EquipmentIsOneHandedWeapon(EquipmentClass mainHandEquipment)
        {
            return mainHandEquipment is OneHandedSword 
                || mainHandEquipment is OneHandedMace 
                || mainHandEquipment is Wand;
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