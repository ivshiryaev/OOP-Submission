using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeOnCollision : MonoBehaviour
{
    [SerializeField] private GameObject playerToSpawn;
    [SerializeField] private Transform spawnPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(other.transform.parent.gameObject);
            Instantiate(playerToSpawn, spawnPos);
        }
    }
}
