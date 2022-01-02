using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float TopZBoundery => 30;
    private float DownZBoundery => -TopZBoundery;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= TopZBoundery
            || transform.position.z <= DownZBoundery)
        {
            Destroy(gameObject);
        }
    }
}
