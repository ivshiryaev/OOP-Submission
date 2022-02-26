using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnCollision : MonoBehaviour
{
    [SerializeField] private string layerToCollide;
    [SerializeField] private float power;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(layerToCollide))
        {
            Debug.Log("OnCollisionEnter");
            collision.rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
}
