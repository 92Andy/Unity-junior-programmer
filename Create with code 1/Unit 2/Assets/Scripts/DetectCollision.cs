using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameOver();
        }
        else if(other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    private void GameOver()
    {
        Debug.Log("GameOver du Bitch!");
        PauseGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

}
