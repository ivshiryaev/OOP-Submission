using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnStart : MonoBehaviour
{
    [SerializeField] float force;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Force);
    }
}
