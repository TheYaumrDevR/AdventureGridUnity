namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Bow : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass offHandEquipment = otherEquipments.GetOffHandEquipment();

            if (null == offHandEquipment || offHandEquipment is ArrowQuiver)
            {
                return true;
            }

            return false;
        }

        public bool CanEquipInOffHand(PlayerEquipmentSlots otherEquipments)
        {
            return false;
        }           
    }
}