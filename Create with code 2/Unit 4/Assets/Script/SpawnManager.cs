using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject powerUpPrefab;

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
            SpawnPowerUp();
            waveCounter++;
        }
    }

    private void SpawnPowerUp()
    {
        var randomPos = GenerateRandomPosition(6f);

        if (powerUpPrefab == null)
            throw new MissingReferenceException("Prefab for power-up was not found!");
        else
            Instantiate(powerUpPrefab, randomPos, powerUpPrefab.transform.rotation);
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
        var randomPos = GenerateRandomPosition(9f);

        if (enemyPrefab == null)
            throw new MissingReferenceException("Prefab for enemy was not found!");
        else
            Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition(float boundery)
    {
        var randomXPos = Random.Range(-boundery, boundery);
        var randomZPos = Random.Range(-boundery, boundery);
        return new Vector3(randomXPos, 0, randomZPos);
    }
}
