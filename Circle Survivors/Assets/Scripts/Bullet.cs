using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Rigidbody2D rb;
	public float moveSpeed;
	public Vector2 moveDirection;
	public int ATK;

	public void Update()
	{
		rb.velocity = moveDirection * moveSpeed;
		
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.layer != 9)
		{
			//Get the collision point
			Vector2 _wallNormal = collision.GetContact(0).normal;

			//Reflect off the wall
			moveDirection = Vector2.Reflect(moveDirection, _wallNormal).normalized;
		}
		else
		{
			ApplyDamage(collision);
			Destroy(this.gameObject);
		}
	}

	public void ApplyDamage(Collision2D collision)
	{
		collision.gameObject.GetComponent<Enemy>().getDamage(ATK);
	}
}
