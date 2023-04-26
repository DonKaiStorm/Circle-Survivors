using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoEWeapon : WeaponBase
{
    public float rotSpeed;
    public List<AoECircle> subCircles;
    public Transform player;
    private Transform weaponTransform;
    // Start is called before the first frame update
    void Start()
    {
        weaponTransform = transform;
        player = gameObject.transform.parent;
        foreach (AoECircle subCircle in subCircles)
		{
            subCircle.ATK = weaponStats.ATK;
		}
        gameObject.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        weaponTransform.position = player.position;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotSpeed);
    }
    

	public override void Attack()
	{
		
	}
}
