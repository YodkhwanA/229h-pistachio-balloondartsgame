using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoints;
    private Wave currentWave;
    private int spawnEmemies = 0;
    private float nextSpawnTime = 0;

    public void SetCurrenWave(Wave wave)
    {
        currentWave = wave;
        spawnEmemies = 0;
        nextSpawnTime = Time.time + 5;
    }

    //void Update()

    //{
    //    if (currentWave == null)
    //    {
    //        return;
    //    }
    //    if (spawnEmemies < currentWave.enemyCount && Time.time > nextSpawnTime)
    //    {
    //        Spawn();
    //        spawnEmemies++;
    //        nextSpawnTime = Time.time + currentWave.spawnTimer;
    //    }


    //}

    //void Spawn()
    //{
    //    var spawnIndex = Random.Range(0, currentWave.enemyPrefab.Length);
    //    var spawnPointIndex = Random.Range(0, spawnPoints.Length);
    //    Instantiate(currentWave.enemyPrefab[spawnIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnIndex].rotation);
    //}
}
