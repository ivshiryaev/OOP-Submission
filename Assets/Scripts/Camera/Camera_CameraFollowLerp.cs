using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_CameraFollowLerp : MonoBehaviour
{

   public Transform cameraLookAt;
    public Transform cameraFollow;

    public float smoothines;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraFollow.position, smoothines * Time.deltaTime);
        transform.LookAt(cameraLookAt.position);
    }
}
