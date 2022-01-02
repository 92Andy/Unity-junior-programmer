using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public GameObject projectilePrefabs;

    private (float leftBoundery, float rightBoundery) bounderies => (-10, 10);

    private float horizontalInput => Input.GetAxis("Horizontal");

    private Vector3 PlayersPosition => transform.position;

    private Vector3 projectileSpwanOffset = new Vector3(0, 0, 1);

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpwanProjectile();
        }
    }

    void ManageMovement()
    {
        var targetPosition = Vector3.right * movementSpeed
        * Time.deltaTime * horizontalInput;

        if (transform.position.x <= bounderies.leftBoundery
            && targetPosition.x < 0)
        {
            return;
        }
        if (transform.position.x >= bounderies.rightBoundery
            && targetPosition.x > 0)
        {
            return;
        }
        transform.Translate(targetPosition);
    }

    void SpwanProjectile()
    {
        Instantiate(projectilePrefabs, PlayersPosition + projectileSpwanOffset,
            projectilePrefabs.transform.rotation);
    }
}
