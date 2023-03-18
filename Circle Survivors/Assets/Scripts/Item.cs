using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public int DEF;

    public void equip(Character player)
	{
        player.DEF += DEF;
	}
    
    public void unEquip(Character player)
	{
        player.DEF -= DEF;
	}
}
