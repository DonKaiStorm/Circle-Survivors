using UnityEngine;

public class Enemy : MonoBehaviour
{
	Transform playerLocation;
	GameObject player;
	Character targetCharacter;
	public EnemyStats stats;
	int currentHP;

	Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		currentHP = stats.maxHP;
	}

	//Sets the target for the enemy to follow when spawning in
	public void SetTarget(GameObject target)
	{
		player = target;
		playerLocation = target.transform;
		targetCharacter = player.GetComponent<Character>();
	}

	public void FixedUpdate()
	{
		Vector3 direction = (playerLocation.position - transform.position).normalized;
		rb.velocity = direction * stats.speed;
	}


	private void OnCollisionStay2D(Collision2D collision)
	{
		//If colliding with the player, attack it.
		if (collision.gameObject == player)
		{
			attack();
		}
	}

	private void attack()
	{
		targetCharacter.TakeDamage(stats.atk);
	}

	public void getDamage(int damage)
	{
		currentHP -= damage;

		if (currentHP <= 0)
		{
			targetCharacter.GetComponent<PlayerLevel>().addExperience(stats.XP);
			Destroy(this.gameObject);
		}
	}
}
