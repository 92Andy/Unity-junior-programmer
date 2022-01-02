using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector3 spawnPosition = new Vector3(25, 0, 0);
    public float repeatingFloat = 2f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObstacle), repeatingFloat, repeatingFloat);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomObstacle()
    {
        if(playerControllerScript.isGameOver == false)
        {
            var randomIndex = Random.Range(0, obstacles.Length - 1);
            Instantiate(obstacles[randomIndex], spawnPosition, obstacles[randomIndex].transform.rotation);
        }
    }
}