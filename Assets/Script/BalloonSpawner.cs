using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq; 

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Transform[] spawnPoints; 
    public int totalRounds = 3;
    private int currentRound = 0;
    private int balloonCount = 0;
    private float[] waveTimes = { 60f, 50f, 40f }; 

    public GameObject gameOverUI; 
    public Button restartButton; 
    void Start()
    {
        gameOverUI.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        StartCoroutine(SpawnRounds());
    }

    IEnumerator SpawnRounds()
    {
        while (currentRound < totalRounds)
        {
            currentRound++;
            

            StartCoroutine(WaveTimer(waveTimes[currentRound - 1]));

            List<Transform> shuffledPoints = spawnPoints.OrderBy(x => Random.value).Take(7).ToList();

           
            foreach (Transform spawnPoint in shuffledPoints)
            {
                Instantiate(balloonPrefab, spawnPoint.position, Quaternion.identity);
                balloonCount++;
            }

            yield return new WaitUntil(() => balloonCount <= 0);

            
        }

        
        SceneManager.LoadSceneAsync("Ending");
    }

    IEnumerator WaveTimer(float time)
    {
        yield return new WaitForSeconds(time);

        if (balloonCount > 0)
        {
            GameOver();
        }
    }

    public void BalloonDestroyed()
    {
        balloonCount--;
    }

    void GameOver()
    {
       
        gameOverUI.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

