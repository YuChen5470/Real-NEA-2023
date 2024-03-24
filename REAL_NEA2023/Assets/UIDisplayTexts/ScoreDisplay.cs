using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public PlayerHealth playerHealth;
    public float scoreCheck;

    void Update()
    {
        scoreCheck = playerHealth.score;
        ScoreText.text = "Score: " + scoreCheck.ToString();
    }
}
