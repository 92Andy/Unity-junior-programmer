using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private float turnSpeed = 1f;

    private float HorizontalInput => Input.GetAxis("Horizontal");
    private float VerticalInput => Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward * VerticalInput);
        transform.Rotate(Vector3.up, HorizontalInput * Time.deltaTime * turnSpeed * VerticalInput);
    }
}
