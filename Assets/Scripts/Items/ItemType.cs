public enum ItemType
{
    HPPack,
    ShieldPack,
    PowerPack
}
public interface Iitem
{
    ItemType GetItemType();
    ItemType GetItemByIndex(int number);
}