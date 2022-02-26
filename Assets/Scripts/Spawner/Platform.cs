#undef DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Transform> spawnPosition;
    [SerializeField] private LayerMask LayerToCheck;

    //Properties
    private float spawnInterval;
    private float destroyInterval;

    private bool isNewPlatformSpawned;

    private PlatformSpawnProperties spawnProperties;


    private void Start()
    {           
        isNewPlatformSpawned = false;

        AssignProperties();

        if (!spawnProperties.isFinalWaveReached)
        {
            StartCoroutine(SpawnPlatform());
            StartCoroutine(DestroyPlatform());
        }

    }


    private void AssignProperties()
    {
        spawnProperties = PlatformSpawnProperties.Instance;
        GetPropertiesFromSpawnPropertiesScript();
    }
    private void GetPropertiesFromSpawnPropertiesScript()
    {
        spawnInterval = spawnProperties.platformSpawnInterval;
        destroyInterval = spawnInterval * spawnProperties.destroyPlatformRelativeToSpawnIntervalValue;
    }
    private void AddSpawnedPlatformToGlobalCount()
    {
        spawnProperties.AddPlatformToSpawnedPlatformsCount();
    }
    private IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(spawnInterval);

        Transform RandomSpawnPosition = GenerateRandomSpawnPosition();

        while (!isNewPlatformSpawned)
        {
            if (IsPositionEmpty(RandomSpawnPosition))
            {
#if DEBUG
                Debug.Log("Random Position is empty, creating platform ....");
#endif
                GameObject instance = Instantiate(prefab, RandomSpawnPosition.position, prefab.transform.rotation);
                instance.transform.SetParent(null);
                isNewPlatformSpawned = true;
                AddSpawnedPlatformToGlobalCount();
            }
            else
            {
#if DEBUG
                Debug.Log("Position isn't empty, trying again....");
#endif
                RandomSpawnPosition = GenerateRandomSpawnPosition();
            }
        }
    }
    private IEnumerator DestroyPlatform()
    {
        yield return new WaitForSeconds(destroyInterval);

        Destroy(gameObject);
    }
    private Transform GenerateRandomSpawnPosition()
    {
#if DEBUG
        Debug.Log("Generating Random Spawn Position ....");
#endif
        Transform RandomSpawnPosition = spawnPosition[UnityEngine.Random.Range(0,spawnPosition.Count)];
#if DEBUG
        Debug.Log("RandomSpawnPosition = " + RandomSpawnPosition.position);
#endif
        return RandomSpawnPosition;
    }
    private bool IsPositionEmpty(Transform check)
    {
#if DEBUG
        Debug.Log("Checking if the position is empty");
#endif
        bool isPositionEmpty = Physics.CheckSphere(check.position, 0.5f, LayerToCheck);
        
        return !isPositionEmpty;
    }
}
