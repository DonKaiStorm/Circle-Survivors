using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] public List<Item> itemList;

	public Character player;

	[SerializeField] Item armorTest;
	private void Awake()
	{
		player.GetComponent<Character>();
	}

	private void Start()
	{
		equip(armorTest);
	}

	public void equip(Item equipItem)
	{
		if(itemList == null)
		{
			itemList = new List<Item>();
		}
		itemList.Add(equipItem);
		equipItem.equip(player);
	}

	public void unEquip(Item unequipItem)
	{
		
	}
}
