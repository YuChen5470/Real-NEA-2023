using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class WaveCountDisplay : MonoBehaviour
{
    public TextMeshProUGUI WaveCountText;
    public SpawningEnemy spawningEnemy;
    public float currentWaveCount;

    void Update()
    {
        currentWaveCount = spawningEnemy.waveCount;
        WaveCountText.text = "Wave: " + currentWaveCount.ToString();
    }
}
