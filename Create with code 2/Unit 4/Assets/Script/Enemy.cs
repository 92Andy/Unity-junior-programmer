using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float speed = 3f;
    private Rigidbody enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        DestoryOnOutOfBound();
    }

    private void MoveToPlayer()
    {
        var directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(directionToPlayer * speed);
    }

    private void DestoryOnOutOfBound()
    {
        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }
}
