// Name: cameraFollow.cs
// Purpose: Works to control the camera movement
// Version 2, April 10, 2021
// Author: Zhandos Shandybayev
// No dependencies 

using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public Transform target;

    [Range(1, 10)]
    public float smoothSpeed;
    public Vector3 offset;

    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.aspect = 16f / 9f;
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.fixedDeltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}