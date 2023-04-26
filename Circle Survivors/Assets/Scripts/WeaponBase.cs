using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
	public WeaponData weaponData;
	public WeaponStats weaponStats;

	public float fireRate;
	float timer;

	private void Update()
	{
		timer -= Time.deltaTime;

		if (timer < 0f)
		{
			Attack();
			fireRate = weaponStats.attackTime;
		}
	}

	public virtual void SetData(WeaponData wD)
	{
		weaponData = wD;
		fireRate = weaponData.stats.attackTime;

		weaponStats = new WeaponStats(wD.stats.ATK, wD.stats.attackTime);
	}

	public abstract void Attack();

	public void Upgrade(UpgradeData upgradeData)
	{
		weaponStats.Sum(upgradeData.weaponUpgradeStats);
	}
}
