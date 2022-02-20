using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetWithOffset : MonoBehaviour
{
    [SerializeField] private GameObject Target;

    [SerializeField] private Vector3 offset;
    void Update()
    {
        transform.position = Target.transform.position + offset;
    }
}
