using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFireRate : MonoBehaviour
{
    // take the current weapon inhand
    // check if currency is ok
    // upgrade a variable 
    [Header("referencing currentWeapon")]
    public GunSwitching gunSwitching; // referencing the gun switching script
    public GameObject weaponToUpgrade; // referencing the object that will be the weapon upgrading

    [Header("Both Weapons")]
    public GameObject SlingShotOne; // referencing first weapon
    public GameObject SlingShotTwo;//  referencing second weapon

    [Header("Getting Script from each object")]
    public GunScript changeHolderScriptOne; //  referencing first weapon gun script
    public GunScript changeHolderScriptTwo;//  referencing second weapon gun script

    [Header("Currency")]
    public PlayerHealth playerHealth; //  references the player health script
    public float fireBuyAmount = 500f; //  amount that delay decrease costs
    public float dmgBuyAmount = 500f;//  amount that upgrading damage costs
    public float _currency;// currency variable
    
    void Start()
    {
        weaponToUpgrade = gunSwitching.currentWeapon; //current weapon inhand
        GunScript changeHolderScriptOne = weaponToUpgrade.GetComponent<GunScript>(); //references the gun script inside the gameobject for slingshot 1
        GunScript changeHolderScriptTwo = weaponToUpgrade.GetComponent<GunScript>(); //references the gun script inside the gameobject for slingshot 2
        _currency = playerHealth.currency; //  references the currency in the playerhealth scripts and sets to the _currency variable
    }

    void Update()
    {
        _currency = playerHealth.currency; // keeps updating the _currency according to the currency from other script
    }

    // Update is called once per frame
    public void UpgradeWeaponDelay()
    {
        //check currency    
        if (_currency - fireBuyAmount >= 0)
        {
            _currency -= fireBuyAmount; // decreases by the cost of delay decrease
            playerHealth.currency -= fireBuyAmount; //  decreases by cost of delay decrease
            fireBuyAmount += 250; // increases cost
            //upgrades the inhand weapon
            if (weaponToUpgrade.name == SlingShotOne.name) //  if statment, checking if the name is the same as the first wepaon name
            {
                if (changeHolderScriptOne.timeBetweenShots -0.025f >=0.1f) // validation, if delay-0.05 is greater than 0, allow to subtract
                {
                    changeHolderScriptOne.timeBetweenShots -= 0.025f;  // subtracts the timebetweenshots, decreasing delay
                }else{
                    Debug.Log("Unable to upgrade, you will have negative or no delay at all...."); //  outputs error message, not enough currency
                }
            
            }else{
                if (changeHolderScriptTwo.timeBetweenShots -0.025f >=0.1f) //  checks if the delay is going too small
                {
                    changeHolderScriptTwo.timeBetweenShots -= 0.025f; //  subtracts if it is not going to after subtraction
                }else{
                    Debug.Log("Unable to upgrade, you will have negative or no delay at all...."); // outputs error message
                }
            }
        }else{
            Debug.Log("You do not have enough money to upgrade your weapon delay"); //  outputs error message
        }
        
        
    }
    public void UpgradeWeaponDamage()
    {
        //check currency
        if (_currency - dmgBuyAmount >= 0) 
        {  
            _currency -= dmgBuyAmount; //  decreases currency by damage increase amount
            playerHealth.currency -= dmgBuyAmount; // decreases currency by damage increase amount
            dmgBuyAmount += 250; //  adds to the cost
            if (weaponToUpgrade.name == SlingShotOne.name) // compares if the weapon in hand is the first weapon

            {
                changeHolderScriptOne.damage += 15f; //  adds damage to the weapon one
            }else{
                changeHolderScriptTwo.damage += 20f; // adds damage to the weapon two
            } 
        }else{
            Debug.Log("You do not have enough money to upgrade your weapon damage"); //  outputs error message
        }
        
    }
}