using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    [Header("Reference")]
    public GeneralDefence generalDefence;

    [Header("Health")]
    public float health = 100f;

    [Header("Score/Currency")]
    public float score = 0f;
    public float currency = 0f;

    [Header("PassiveHealing")]
    public bool Unlocked;
    public float Reg_timer = 0;


    [Header("crosshair")]
    public GameObject crosshair;
    

    void Update()
    {
        Unlocked = generalDefence.isUnlocked;
        if (Unlocked)
        {
            PassiveHealthReg();
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            crosshair.SetActive(false);
            SceneManager.LoadScene("Menu");
        }
    }
    public void AddRewards(float enemyScore, float enemyMoney)
    {
        score += enemyScore;
        currency += enemyMoney;
    }


    public void PassiveHealthReg()
    {
        if (health < 100)
        {
            if (Reg_timer >= 5)
            {
                
                Debug.Log(Reg_timer);
                health += 1f;
                Debug.Log(health);
                Reg_timer = 0; //resets timer back to 0
            }
            else
            {
                Reg_timer += Time.deltaTime;
                Debug.Log(Reg_timer);

            }
        }
        health = Mathf.Clamp(health, 0 ,100);

    }
}


