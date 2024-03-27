using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    [Header("Reference")]
    public GeneralDefence generalDefence; // referencing script general defence

    [Header("Health")]
    public float health = 100f; //sets health to 100

    [Header("Score/Currency")]
    public float score = 0f; //sets score to 0
    public float currency = 0f; // sets currency to 0
 
    [Header("PassiveHealing")]
    public bool Unlocked; // variable checking for locked or unlocked
    public float Reg_timer = 0; //regeneration timer initially set to 0


    [Header("crosshair")]
    public GameObject crosshair; // gets gameobject called crosshair
    

    void Update()
    {
        Unlocked = generalDefence.isUnlocked; 
        // references the general defence script's variable called isunlocked, sets it as a variable in this script
        if (Unlocked)
        {
            PassiveHealthReg(); // if the user has unlocked passive healing, function will repeatedly run
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage; //taking damage from enemy
        if (health <= 0) 
        //if health reaches below or 0, sends user back to main menu and unlocks their cursor to potentially play again
        {
            Cursor.lockState = CursorLockMode.None; // cursor is unlocked
            Cursor.visible = true; // cursor is set visible
            crosshair.SetActive(false); // crosshair is disabled
            SceneManager.LoadScene("Menu"); // scene changes to menu scene
        }
    }
    public void AddRewards(float enemyScore, float enemyMoney)
    {
        score += enemyScore; // adds the players score with whatever score enemy gives
        currency += enemyMoney; // adds the players currency with whatever currency enemy gives
    }


    public void PassiveHealthReg()
    {
        if (health < 100) // if the player is at maximum health, this wont happen
        {
            if (Reg_timer >= 5) //check regeneration timer, if it has not been 5 frames, nothing will happen, only add more frames
            {
                
                health += 1f; //adds 1 health per 5 frames
                Debug.Log(health); // outputs health
                Reg_timer = 0; //resets timer back to 0
            }
            else
            {
                Reg_timer += Time.deltaTime; // adds frames to reg timer

            }
        }
        health = Mathf.Clamp(health, 0 ,100); // rounds the health

    }
}


