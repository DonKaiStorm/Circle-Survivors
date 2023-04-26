using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public int maxHP = 40;
    public int currentHP = 40;
	public float hpRegenRate = 1f;
	public float hpRegenTimer;
	public int DEF;

    public HPBar healthBar;
	public PauseMenuManager pauseMenuManager;
	public AudioSource hitSound;

	public void TakeDamage(int damage)
	{
		applyDEF(ref damage);
		hitSound.PlayOneShot(hitSound.clip, 1);
        currentHP -= damage;
        healthBar.UpdateHP();
        if (currentHP <= 0)
		{
			Death();
		}
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			pauseMenuManager.Pause();
		}
		hpRegenTimer += Time.deltaTime * hpRegenRate;
		if (hpRegenTimer > 1f)
		{
			if (currentHP != maxHP)
			{
				heal(1);
			}
			hpRegenTimer -= 1f;
		}
	}

	private void heal(int hpRegen)
	{
		currentHP += hpRegen;
		healthBar.UpdateHP();
	}

	public void applyDEF(ref int damage)
	{
		damage -= DEF;
		if (damage < 0)
		{
			damage = 0;
		}
	}

	//Reloads current scene upon death
	public void Death()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
