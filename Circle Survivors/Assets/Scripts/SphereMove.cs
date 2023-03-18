using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class SphereMove : MonoBehaviour
{

	Rigidbody2D rb;
	Vector2 movementVec;
	Vector2 mousePos;

	[SerializeField]
	float speed = 4;
	[SerializeField] private Camera cam;

	public PassiveItems playerItemList;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//Gather the X & Y Input, and multiply by the speed value (normalize it after gaining inputs so the diagonals don't go faster than WS and AD axes)
		movementVec.x = Input.GetAxisRaw("Horizontal");
		movementVec.y = Input.GetAxisRaw("Vertical");
		movementVec = movementVec.normalized;
		movementVec *= speed;

		//Apply movementvector to the Sphere Rigidbody
		rb.velocity = movementVec;

		//Gets our mouse position in terms of location in the world
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

		//Rotates the sphere based on look direction
		Vector2 lookDirection = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
		rb.rotation = angle;

		if (Input.GetKeyDown(KeyCode.P))
		{
			playerItemList.unEquip(playerItemList.itemList.First());
		}
	}
}
