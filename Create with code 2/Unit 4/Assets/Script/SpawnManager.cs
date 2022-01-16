using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float xzSpawnBoundery = 9f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyOnRandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        
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
