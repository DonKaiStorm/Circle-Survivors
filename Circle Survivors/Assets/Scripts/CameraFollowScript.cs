using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform camTransform;
    public Transform playerTransform;

    void Update()
    {
        camTransform.localPosition = new Vector3 (playerTransform.localPosition.x, playerTransform.localPosition.y, camTransform.localPosition.z);

    }
}
