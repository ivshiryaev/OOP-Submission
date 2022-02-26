using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float xRangeRandomSpawnPos, yRangeRandomSpawnPos, zRangeRandomSpawnPos;
    [SerializeField] List<GameObject> spawnObject;
    private int spawnCount = 1;

    private void Start()
    {
        spawnCount = PlatformSpawnProperties.Instance.enemiesToSpawnCount;

        while (spawnCount != 0)
        {
            SpawnObject();
            spawnCount--;
        }
    }
    private void SpawnObject()
    {
        int randomSpawnObject = Random.Range(0, spawnObject.Count);
        Instantiate(spawnObject[randomSpawnObject], RandomSpawnPosition(), spawnObject[randomSpawnObject].transform.rotation);
    }
    Vector3 RandomSpawnPosition()
    {
        float xRandomPos = Random.Range(transform.position.x - xRangeRandomSpawnPos, transform.position.x + xRangeRandomSpawnPos);
        float yRandomPos = Random.Range(transform.position.y - yRangeRandomSpawnPos, transform.position.y + yRangeRandomSpawnPos);
        float zRandomPos = Random.Range(transform.position.z - xRangeRandomSpawnPos, transform.position.z + zRangeRandomSpawnPos);

        return new Vector3(xRandomPos, yRandomPos, zRandomPos);
    }
}
