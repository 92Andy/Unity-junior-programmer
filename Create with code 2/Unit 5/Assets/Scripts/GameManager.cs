using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI liveTMP;
    public TextMeshProUGUI gameOverTMP;
    public Button restartButton;

    public bool isGameActive;

    private float spawnRate = 1f;
    private int score = 0;
    private int amountOfLive = 3;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;

        if (targets.Count == 0)
            throw new MissingComponentException("Their are no Targets!");
        StartCoroutine(SpawnTargets());

        UpdateScore(0);
        UpdateLiveTmpText(amountOfLive);
    }

    private IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            var randomIndex = Random.Range(0, targets.Count);
            Instantiate(targets.ElementAt(randomIndex));
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0)
            score = 0;
        scoreTMP.text = "Score: " + score.ToString();
    }

    private void UpdateLiveTmpText(int live)
    {
        if (live == 0)
            liveTMP.text = string.Empty;

        var tmpLiveText = string.Empty;
        for(int i = 0; i < live; i++)
        {
            tmpLiveText += " |";
        }

        liveTMP.text = tmpLiveText;
    }

    public void ReduceLive()
    {
        if (amountOfLive == 0)
            GameOver();
        amountOfLive--;
        UpdateLiveTmpText(amountOfLive);
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        gameOverTMP.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
