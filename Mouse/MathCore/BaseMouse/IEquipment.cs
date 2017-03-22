namespace MathCore
{
    public interface IEquipment
    {
        Slot EquipSlot { get;}
        float bonus { get; }
    }
    public enum Slot
    {
        Shoes,
        Body,
        Head
    }
}