namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes
{
    public class ArrowQuiver : EquipmentClass
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