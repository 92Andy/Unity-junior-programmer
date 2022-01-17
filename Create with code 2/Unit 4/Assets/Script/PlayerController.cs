using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float speed = 5f;

    public bool pickedPowerUp = false;
    private float powerUpStrength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = focalPoint.transform.forward;
        playerRb.AddForce(direction * verticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            StartCoroutine(HandlePowerUpPickedRoutine());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && pickedPowerUp)
        {
            PushEnemyAway(collision.gameObject);
        }
    }

    private IEnumerator HandlePowerUpPickedRoutine()
    {
        pickedPowerUp = true;
        yield return new WaitForSeconds(7);
        pickedPowerUp = false;
    }

    private void PushEnemyAway(GameObject enemy)
    {
        var enemyRb = enemy.GetComponent<Rigidbody>();
        var awayFromPlayer = enemyRb.position - transform.position;

        enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
    }
}
