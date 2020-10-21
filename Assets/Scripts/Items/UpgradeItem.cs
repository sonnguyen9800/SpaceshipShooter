using UnityEngine;
public interface IUpgradeComponent
{
    void Upgrade();
}
[RequireComponent(typeof(Item))]
public class UpgradeItem : MonoBehaviour
{
    private Item item;
    private void Awake()
    {
        item = GetComponent<Item>();
        item.OnPick += Upgrade;
    }
    private void Upgrade(Collider2D other)
    {
        IUpgradeComponent upgradeComponent = other.GetComponent<IUpgradeComponent>();
        if (upgradeComponent == null) return;
        upgradeComponent.Upgrade();
    }
}
