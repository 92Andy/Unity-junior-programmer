using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private int SpawnZPosition => 25;
    private float SpawnInSeconds = .5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal),
            SpawnInSeconds, SpawnInSeconds);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnRandomAnimal()
    {
        var randomAnimalIndex = Random.Range(0, animalPrefabs.Length);
        var randomAnimal = animalPrefabs[randomAnimalIndex];
        var randomXPosition = Random.Range(-10, 10);
        Instantiate(randomAnimal,
            new Vector3(randomXPosition, 0, SpawnZPosition),
            randomAnimal.transform.rotation); ;
    }
}
