using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue = 0;
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float spawnYPos = -2;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager")
            .GetComponent<GameManager>();
        SpawnAndMoveTarget();
    }

    private void SpawnAndMoveTarget()
    {
        transform.position = RandomSpawnPos();
        targetRb.AddForce(RandomUpForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorqueForce());
    }

    private Vector3 RandomTorqueForce()
    {
        var randomX = UnityEngine.Random.Range(-10f, 10f);
        var randomY = UnityEngine.Random.Range(-10f, 10f);
        var randomZ = UnityEngine.Random.Range(-10f, 10f);
        return new Vector3(randomX, randomY, randomZ);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(UnityEngine.Random.Range(-8f, 8f), spawnYPos);
    }

    private Vector3 RandomUpForce()
    {
        return Vector3.up * UnityEngine.Random.Range(10f, 16f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sensor"))
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
    }
}
