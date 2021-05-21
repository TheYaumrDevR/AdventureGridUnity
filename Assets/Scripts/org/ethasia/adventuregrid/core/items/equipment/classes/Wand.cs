namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class Wand : EquipmentClass
    {
        public bool CanEquipInMainHand(PlayerEquipmentSlots otherEquipments)
        {
            EquipmentClass offHandEquipment = otherEquipments.GetOffHandEquipment();

            if (offHandEquipment is ArrowQuiver || offHandEquipment is BoltQuiver)
            {
                return false;
            }

            return true;
        }

        public bool CanEquipInOffHand()
        {
            return true;
        }           
    }
}