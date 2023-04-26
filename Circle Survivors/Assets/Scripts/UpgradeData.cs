using UnityEngine;
public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgrade,
    UnlockWeapon,
    UnlockItem
}
[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;

    public WeaponData weaponData;
    public WeaponStats weaponUpgradeStats;

}
