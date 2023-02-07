using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SphereMove : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 movementVec;

    [SerializeField]
    float speed = 4;

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
    }
}
