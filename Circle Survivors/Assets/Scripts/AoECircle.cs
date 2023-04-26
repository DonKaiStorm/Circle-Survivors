using UnityEngine;

public class AoECircle : MonoBehaviour
{
    // Start is called before the first frame update
    public int ATK;

	private void OnCollisionStay2D(Collision2D collision)
	{
		if(collision.gameObject.layer == 9)
		{
			ApplyDamage(collision);
		}
	}

	private void ApplyDamage(Collision2D collision)
	{
		collision.gameObject.GetComponent<Enemy>().getDamage(ATK);
	}

}
