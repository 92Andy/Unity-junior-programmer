using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float xzSpawnBoundery = 9f;

    private int waveCounter = 1;

    // Update is called once per frame
    void Update()
    {
        HandleWave();
    }

    private void HandleWave()
    {
        var enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            SpawnEnemyWaves(waveCounter);
            waveCounter++;
        }
    }

    private void SpawnEnemyWaves(int amountOfWaves)
    {
        for(int i = 0; i < amountOfWaves; i++)
        {
            SpawnEnemyOnRandomPos();
        }
    }

    private void SpawnEnemyOnRandomPos()
    {
        var randomPos = GenerateRandomPosition();

        if (enemyPrefab == null)
            throw new MissingReferenceException("Prefab for enemy was not found!");
        else
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        var randomXPos = Random.Range(-xzSpawnBoundery, xzSpawnBoundery);
        var randomZPos = Random.Range(-xzSpawnBoundery, xzSpawnBoundery);
        return new Vector3(randomXPos, 0, randomZPos);
    }
}
