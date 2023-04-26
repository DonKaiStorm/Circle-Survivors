using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponStats
{
    public int ATK;
    public float attackTime;
    public int ricochetChance; 

    public WeaponStats(int damage, float rateOfAttack)
	{
        ATK = damage;
        attackTime = rateOfAttack;
	}

	public void Sum(WeaponStats weaponUpgradeStats)
	{
        ATK += weaponUpgradeStats.ATK;
        attackTime -= weaponUpgradeStats.attackTime;
        ricochetChance = weaponUpgradeStats.ricochetChance;
	}
}


[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public string Name;
    public WeaponStats stats;
    public GameObject weaponBasePrefab;
    public List<UpgradeData> upgrades;
}
