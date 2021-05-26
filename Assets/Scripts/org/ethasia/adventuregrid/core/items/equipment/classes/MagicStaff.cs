namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class MagicStaff : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass offHandEquipment = otherEquipments.GetOffHandEquipment();

            if (null != offHandEquipment)
            {
                return false;
            }

            return true;
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