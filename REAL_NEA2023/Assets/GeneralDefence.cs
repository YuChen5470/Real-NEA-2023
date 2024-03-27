using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDefence : MonoBehaviour
{
    [Header("Currency")]
    public WeaponShop weaponShop; // references the weapon shop script
    public PlayerMovement playerMovement; //  references the player movement script
    public PlayerHealth playerHealth; //  references the player health script
    public float ptnsBuyAmount = 500f; // cost of potions
    public float pashpBuyAmount = 500f; // cost of passive health regeneration
    private float _currency; // _currency variable
    private float _playerHealth; // _playerHealth variable


    [Header("PassiveHealing")]
    public bool isUnlocked; // boolean checking for passive health unlocked or not
    public float Reg_timer = 0; //regeneration timer, time between each tick of health
    
   

    [Header("Potion stats")]
    public float PotRegen = 50f; // how much potions give the player
    void Start()
    {
        _currency = playerHealth.currency; // defines _currency as the playerhealth's currency
        _playerHealth = playerHealth.health; // defines _playerHealth as the playerhealth's health
        isUnlocked = false; // sets isUnlocked to false initially
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PurcahsePotions()
    {
        //check currency
        if (playerHealth.currency - ptnsBuyAmount >= 0) //checking if the player is able to buy the potions
        {
            if (playerHealth.health + PotRegen > 100) // if the potion is going to heal the user to more than 100 health, set to 100 health instead
            {
                
                playerHealth.currency -= ptnsBuyAmount; // subtract currency by the potions cost

                playerHealth.health = 100; // set the players health to 100
                
            }else{
                
                playerHealth.currency -= ptnsBuyAmount; // subtracts currency by the potions cost
            
                playerHealth.health += PotRegen; // adds the current health with the potion regeneration amount
            }
            
        }else{
            Debug.Log("You don't have enought currency to purchase potions."); //outputs error message
        }
    }

    public void UnlockPashp()
    {
        if (_currency - pashpBuyAmount >= 0) // checks if the player is able to buy the passive health regeneration
        {
            _currency -= pashpBuyAmount; // subtracts currency by the cost of passive health regeneration
            playerHealth.currency -= pashpBuyAmount; // subtract currency by the cost of the passive health regeneration
            isUnlocked = true; // sets isUnlocked to true, which will trigger an event in another script
            Debug.Log("Purchased passive healing."); // outputs message telling user that it was successful.

        }else{
            Debug.Log("you don't have enough currency"); //outputs error message.
        }
    }


}
