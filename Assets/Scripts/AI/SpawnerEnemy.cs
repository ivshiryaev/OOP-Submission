using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : BaseEnemy
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnInterval;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 spawnPosition = transform.position + Vector3.up;

            Instantiate(prefab, spawnPosition, prefab.transform.rotation);
        }
    }
}
