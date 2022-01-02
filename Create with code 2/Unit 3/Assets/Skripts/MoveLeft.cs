using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 10f;

    private PlayerController playerControllerScript;
    private float xOutOfBoundPos => -12;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftOnPlay();
        DestroyObstaclesOutOfBound();
    }

    void MoveLeftOnPlay()
    {
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void DestroyObstaclesOutOfBound()
    {
        if ( gameObject.CompareTag("Obstacle")
            && transform.position.x <= xOutOfBoundPos)
        {
            Destroy(gameObject);
        }
    }
}
