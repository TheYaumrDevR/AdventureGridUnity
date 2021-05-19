namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class MagicStaff : EquipmentClass
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