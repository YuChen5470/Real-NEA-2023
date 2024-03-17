using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDefence : MonoBehaviour
{
    [Header("Currency")]
    public PlayerHealth playerHealth;
    public float ptnsBuyAmount = 500f;
    public float pashpBuyAmount = 500f;
    private float _currency;
    private float _playerHealth;

    [Header("PassiveHealing")]
    public bool isUnlocked = false;
    public float maxHealth = 100f;

    [Header("Potion stats")]
    public float PotRegen = 50f;
    void Start()
    {
        _currency = playerHealth.currency;
        _playerHealth = playerHealth.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurcahsePotions()
    {
        //check currency
        if (_currency - ptnsBuyAmount >= 0)
        {
            if (playerHealth.health + PotRegen > 100)
            {
                _currency -= ptnsBuyAmount;
                playerHealth.currency -= ptnsBuyAmount;

                playerHealth.health = 100;
                
            }else{
                _currency -= ptnsBuyAmount;
                playerHealth.currency -= ptnsBuyAmount;
            
                playerHealth.health += PotRegen; 
            }
            
        }else{
            Debug.Log("You don't have enought currency to purchase potions.");
        }
    }

    public void UnlockPashp()
    {
        if (_currency - pashpBuyAmount >= 0)
        {
            _currency -= pashpBuyAmount;
            playerHealth.currency -= pashpBuyAmount;
            PassiveHealing();

        }else{
            Debug.Log("you don't have enough currency");
        }
    }

    public void PassiveHealing()
    {
    
    }


}
