using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject cam;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, cam.transform.position.z);

    }
}
