using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [Header("Health")]
    public float health = 100f;

    [Header("Score/Currency")]
    public float score = 0f;
    public float currency = 0f;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddRewards(float enemyScore, float enemyMoney)
    {
        score += enemyScore;
        currency += enemyMoney;
    }
}

