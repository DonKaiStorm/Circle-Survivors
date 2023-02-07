using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] Transform playerLocation;
	GameObject player;
	[SerializeField] float speed;

	Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		player = playerLocation.gameObject;
	}

	public void FixedUpdate()
	{
		Vector3 direction = (playerLocation.position - transform.position).normalized;
		rb.velocity = direction * speed;
	}


	private void OnCollisionStay2D(Collision2D collision)
	{
		//If colliding with the player, attack it.
		if (collision.gameObject == player)
		{
			Attack();
		}
	}

	private void Attack()
	{
		Debug.Log("Striking the Sphere, in case it's not clear.");
	}
}
