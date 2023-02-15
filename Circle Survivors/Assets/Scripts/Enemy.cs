using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] Transform playerLocation;
	GameObject player;
	Character targetCharacter;
	public EnemyStats stats;
	int currentHP;

	Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		player = playerLocation.gameObject;
		currentHP = stats.maxHP;
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
			Destroy(this.gameObject);
		}
	}
}
