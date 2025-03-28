using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject balloonPrefab;
    public Transform[] spawnPoints; // �ش�Դ�١��
    public int totalRounds = 3;
    private int currentRound = 0;
    private int balloonCount = 0; 

    void Start()
    {
        StartCoroutine(SpawnRounds());
    }

    IEnumerator SpawnRounds()
    {
        while (currentRound < totalRounds)
        {
            currentRound++;
            Debug.Log("������ǿ��� " + currentRound);

            
            foreach (Transform spawnPoint in spawnPoints)
            {
                Instantiate(balloonPrefab, spawnPoint.position, Quaternion.identity);
                balloonCount++; 
            }

            
            yield return new WaitUntil(() => balloonCount <= 0);

            Debug.Log("�ǿ " + currentRound + " ��");
        }

        
        SceneManager.LoadScene("NextScene"); 
    }

    
    public void BalloonDestroyed()
    {
        balloonCount--;
    }
}

