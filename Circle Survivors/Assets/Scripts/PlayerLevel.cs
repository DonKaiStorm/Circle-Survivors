using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
	public int level = 1;
	public int experience = 0;
	public XPBar xpBar;
	public UpgradeUIManager upgradeMenu;

	[SerializeField] List<UpgradeData> upgrades;
	List<UpgradeData> selectedUpgrades;

	[SerializeField]  List<UpgradeData> aquiredUpgrades;

	WeaponManager weaponManager;

	public void Awake()
	{
		weaponManager = GetComponent<WeaponManager>();
	}

	public int TO_LEVEL_UP
	{
		get
		{
			return level * 100;
		}
	}

	public void Start()
	{
		xpBar.UpdateXP();
		xpBar.setLevelText();
	}

	public void addWeaponSpecificUpgrades(List<UpgradeData> upgradesToAdd)
	{
		upgrades.AddRange(upgradesToAdd);
	}

	public void addExperience(int amount)
	{
        experience += amount;
        checkLevelUp();
		xpBar.UpdateXP();
		
	}

    public void checkLevelUp()
	{
		if (experience >= TO_LEVEL_UP)
		{
			levelUp();
		}
	}

	public void Upgrade(int selectedUpgradeID)
	{
		UpgradeData upgradeData = selectedUpgrades[selectedUpgradeID];

		if (aquiredUpgrades == null)
		{
			aquiredUpgrades = new List<UpgradeData>();
		}

		switch (upgradeData.upgradeType)
		{
			case UpgradeType.WeaponUpgrade:
				weaponManager.UpgradeWeapon(upgradeData);
				break;
			case UpgradeType.ItemUpgrade:
				break;
			case UpgradeType.UnlockItem:
				break;
			case UpgradeType.UnlockWeapon:
				weaponManager.addWeapon(upgradeData.weaponData);
				break;
		}
		aquiredUpgrades.Add(upgradeData);
		upgrades.Remove(upgradeData);
	}

	private void levelUp()
	{
		if (selectedUpgrades == null)
		{
			selectedUpgrades = new List<UpgradeData>();
		}
		selectedUpgrades.Clear();
		selectedUpgrades.AddRange(getUpgrades(3));


		upgradeMenu.openUI(selectedUpgrades);
		experience -= TO_LEVEL_UP;
		level += 1;
		xpBar.setLevelText();
	}

	public List<UpgradeData> getUpgrades(int count)
	{
		List<UpgradeData> upgradeList = new List<UpgradeData>();
		int prevUpgrade = -1;

		if (count > upgrades.Count)
		{
			count = upgrades.Count;
		}

		for (int i = 0; i < count; i++)
		{
			int currentUpgrade = Random.Range(0, upgrades.Count);
			if (currentUpgrade == prevUpgrade)
			{
				do
				{
					currentUpgrade = Random.Range(0, upgrades.Count);
				} while (currentUpgrade == prevUpgrade);
			}
			upgradeList.Add(upgrades[currentUpgrade]);
			prevUpgrade = currentUpgrade;
		}
		return upgradeList;
	}
}
