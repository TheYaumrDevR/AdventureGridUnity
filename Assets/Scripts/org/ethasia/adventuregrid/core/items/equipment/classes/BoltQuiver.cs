namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class BoltQuiver : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass mainHandEquipment = otherEquipments.GetMainHandEquipment();

            if (!(null == mainHandEquipment || mainHandEquipment is CrossBow))
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
    }
}