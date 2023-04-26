using UnityEngine;

public class BulletSpawn : WeaponBase
{
	public Transform firePoint;
	public GameObject bullet;
	public Camera mainCamera;

	public void Start()
	{
		mainCamera = Camera.main;
	}
	// Update is called once per frame
	public void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.timeScale != 0f)
		{
			InvokeRepeating("Attack", 0f, fireRate);
		}

		if (Input.GetButtonUp("Fire1"))
		{
			CancelInvoke("Attack");
		}

		fireRate = weaponStats.attackTime;
	}

	public override void Attack()
	{
		//Instantiate the bullet
		GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.root.rotation);
		Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>();

		//Ensures firing speed is consistent even when changing click distance from player
		Vector3 shootDirection;
		shootDirection = Input.mousePosition;
		shootDirection.z = 0.0f;
		shootDirection = mainCamera.ScreenToWorldPoint(shootDirection);
		shootDirection -= transform.position;

		//Set direction & Set Damage to Spawner Damage
		rb.GetComponent<Bullet>().moveDirection = new Vector2(shootDirection.x, shootDirection.y).normalized;
		bulletInstance.GetComponent<Bullet>().ATK = weaponStats.ATK;
		bulletInstance.GetComponent<Bullet>().ricochetChance = weaponStats.ricochetChance;

		//Play SFX
		GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip, 1f);
	}
}