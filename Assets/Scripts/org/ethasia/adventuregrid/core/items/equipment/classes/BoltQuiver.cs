namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class BoltQuiver : EquipmentClass
    {
        public bool CanEquipInMainHand()
        {
            return false;
        }

        public bool CanEquipInOffHand()
        {
            return true;
        }                   
    }
}