using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class PlayerHealthCurrent : MonoBehaviour
{
    public TextMeshProUGUI PlayerHealthText;
    public PlayerHealth playerHealth;
    public float currentHealth;

    void Update()
    {
        currentHealth = playerHealth.health;
        PlayerHealthText.text = "Current Health: " + currentHealth.ToString();
    }


}
