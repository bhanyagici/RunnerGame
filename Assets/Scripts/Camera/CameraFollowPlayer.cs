using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform cameraTarget;
    public float sSpeed = 10.0f;
    public Vector3 distance;
    public Transform lookTarget;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget);
    }

}
