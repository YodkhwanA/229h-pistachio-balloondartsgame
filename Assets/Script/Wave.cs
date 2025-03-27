using UnityEngine;

public class Wave : MonoBehaviour
{
    public Wave[] waves;
    public WaveController waveController;
    private int currentWaveIndex = 0;
    private float currentWaveEndTime = 0;
}
