using UnityEngine;

public class BulletSpawn : MonoBehaviour
{

	public Transform firePoint;
	public GameObject bullet;
	public float fireRate;
	public Camera mainCamera;

	public void Start()
	{
		mainCamera = Camera.main;
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			InvokeRepeating("Shoot", 0f, fireRate);
		}

		if (Input.GetButtonUp("Fire1"))
		{
			CancelInvoke("Shoot");
		}
	}

	void Shoot()
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

		//Set direction
		rb.GetComponent<Bullet>().moveDirection = new Vector2(shootDirection.x, shootDirection.y).normalized;
	}
}