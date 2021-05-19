namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class CrossBow : EquipmentClass
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