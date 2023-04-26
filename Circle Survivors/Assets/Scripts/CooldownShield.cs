using UnityEngine;

public class CooldownShield : WeaponBase
{
    public Transform player;
    private Transform shieldTransform;
    // Start is called before the first frame update
    void Start()
    {
        shieldTransform = transform;
        player = gameObject.transform.parent;
        gameObject.transform.parent = null;
        gameObject.SetActive(false);
        Invoke("Activate", weaponStats.attackTime);
    }

    // Update is called once per frame
    void Update()
    {
        shieldTransform.localPosition = player.position;
    
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 9 && gameObject.activeSelf)
		{
            collision.gameObject.GetComponent<Enemy>().getDamage(weaponStats.ATK);
            gameObject.SetActive(false);
            Invoke("Activate", weaponStats.attackTime);
        }
	}
	public void Activate()
	{
        gameObject.SetActive(true);
	}
    public override void Attack()
    {

    }
}
