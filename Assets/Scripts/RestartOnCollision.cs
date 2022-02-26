using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            GameManager.Instance.RestartScene();
    }
}
