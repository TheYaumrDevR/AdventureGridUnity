namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class CrossBow : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass offHandEquipment = otherEquipments.GetOffHandEquipment();

            if (null == offHandEquipment || offHandEquipment is BoltQuiver)
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