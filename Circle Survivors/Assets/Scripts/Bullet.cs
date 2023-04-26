using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
	public System.Random random;
	public Rigidbody2D rb;
	public float moveSpeed;
	public Vector2 moveDirection;
	public int ATK;
	public int ricochetChance;

	public void FixedUpdate()
	{
		rb.velocity = moveDirection * moveSpeed;
	}

	public void Start()
	{
		random = new System.Random();
		Invoke("DespawnBullet", 3f);
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
			int randomChance = random.Next(0, 100);
			if (ricochetChance >= randomChance)
			{
				//Get the collision point
				Vector2 _wallNormal = collision.GetContact(0).normal;

				//Reflect off the enemy
				moveDirection = Vector2.Reflect(moveDirection, _wallNormal).normalized;
			}
			else
			{
				Destroy(this.gameObject);
			}
		}
	}

	public void ApplyDamage(Collision2D collision)
	{
		collision.gameObject.GetComponent<Enemy>().getDamage(ATK);
	}
	
	public void DespawnBullet()
	{
		Destroy(this.gameObject);
	}
}
