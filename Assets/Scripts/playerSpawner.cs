using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawner : MonoBehaviour
{
    public enum PlayerType
    {
        Light,
        Medium,
        Heavy
    }

    [SerializeField] private List<GameObject> player;
    [SerializeField] private PlayerType playerToSpawn;

    private void Start()
    {
        SpawnPlayer();
    }
    void SpawnPlayer()
    {
        if (playerToSpawn == PlayerType.Light)
            Instantiate(player[0], transform);
        if (playerToSpawn == PlayerType.Medium)
            Instantiate(player[1], transform);
        if (playerToSpawn == PlayerType.Heavy)
            Instantiate(player[2], transform);
    }
}
