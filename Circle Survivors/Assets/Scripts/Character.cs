using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHP = 40;
    public int currentHP = 40;

    public void TakeDamage(int damage)
	{
        currentHP -= damage;

        if (currentHP <= 0)
		{
            Debug.Log("Welp, you should be dead...");
		}
	}
}
