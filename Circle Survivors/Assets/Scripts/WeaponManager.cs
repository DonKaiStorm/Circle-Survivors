using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Transform weaponObjectsContainer;

	[SerializeField] WeaponData startingWeapon;

	List<WeaponBase> weapons;

	private void Awake()
	{
		weapons = new List<WeaponBase>();
	}
	private void Start()
	{
		addWeapon(startingWeapon);
	}
	public void addWeapon(WeaponData weaponData)
	{
		GameObject weaponGameObject = Instantiate(weaponData.weaponBasePrefab, weaponObjectsContainer);

		WeaponBase weaponBase = weaponGameObject.GetComponent<WeaponBase>();

		weaponBase.SetData(weaponData);
		weapons.Add(weaponBase);

		PlayerLevel playerLevel = GetComponent<PlayerLevel>();
		if (playerLevel != null)
		{
			playerLevel.addWeaponSpecificUpgrades(weaponData.upgrades);
		}
	}

	public void UpgradeWeapon(UpgradeData upgradeData)
	{
		WeaponBase weaponUpgraded = weapons.Find(wd => wd.weaponData == upgradeData.weaponData);

		weaponUpgraded.Upgrade(upgradeData);
	}
}
