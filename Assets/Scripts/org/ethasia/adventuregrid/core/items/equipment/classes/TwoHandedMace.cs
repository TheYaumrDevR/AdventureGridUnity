namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class TwoHandedMace : EquipmentClass
    {
        public bool CanEquipInMainHand()
        {
            return true;
        }

        public bool CanEquipInOffHand()
        {
            return false;
        }           
    }
}