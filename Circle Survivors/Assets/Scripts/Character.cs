using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHP = 40;
    public int currentHP = 40;
	public int DEF;

    public HPBar healthBar;
    public float bulletFireRate = 0.1f;
	public void Awake()
	{
		gameObject.GetComponent<BulletSpawn>().fireRate = bulletFireRate;
	}
	public void TakeDamage(int damage)
	{
		applyDEF(ref damage);

        currentHP -= damage;
        healthBar.UpdateHP();
        if (currentHP <= 0)
		{
            Debug.Log("Welp, you should be dead...");
		}
	}

	public void applyDEF(ref int damage)
	{
		damage -= DEF;
		if (damage < 0)
		{
			damage = 0;
		}
	}
}
