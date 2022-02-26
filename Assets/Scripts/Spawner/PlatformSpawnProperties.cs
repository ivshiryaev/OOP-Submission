#define DEBUG
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnProperties : MonoBehaviour
{
    public static PlatformSpawnProperties Instance { get; private set; }
    public static int spawnWave { get; private set; }

    [field: SerializeField] public float platformSpawnInterval { get; private set; }
    [field: SerializeField] public float destroyPlatformRelativeToSpawnIntervalValue { get; private set; }


    [SerializeField] private int eachWaveToIncreaseDifficulty;
    [SerializeField] private float increaseDifficultyMultiplier;

    [SerializeField] private int finalWave;
    public bool isFinalWaveReached { get; private set; }


    [field: SerializeField] public int enemiesToSpawnCount { get; private set; }


    private void Awake()
    {
        isFinalWaveReached = false;
        Instance = this;
        spawnWave = 0;
    }


    public void AddPlatformToSpawnedPlatformsCount()
    {
        spawnWave++;
#if DEBUG
        Debug.Log("SpawnWave + 1..... spawnWave = " + spawnWave);
#endif
        TryIncreaseDifficulty();
        CheckIsFinalWaveReached();
    }
    private void CheckIsFinalWaveReached()
    {
        isFinalWaveReached = spawnWave >= finalWave ? true : false;
    }
    private void TryIncreaseDifficulty()
    {
        if (IsSpawnWaveMultipleToValue(eachWaveToIncreaseDifficulty))
            IncreaseDifficulty(increaseDifficultyMultiplier);

    }
    private bool IsSpawnWaveMultipleToValue(int value)
    {
        int temp = spawnWave % value;
        return temp == 0 ? true : false;
    }
    private void IncreaseDifficulty(float value)
    {
        platformSpawnInterval *= value;
        enemiesToSpawnCount++;
    }
}
