using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFireRate : MonoBehaviour
{
    // take the current weapon inhand
    // check if currency is ok
    // upgrade a variable 
    [Header("referencing currentWeapon")]
    public GunSwitching gunSwitching;
    public GameObject weaponToUpgrade;

    [Header("Both Weapons")]
    public GameObject SlingShotOne;
    public GameObject SlingShotTwo;

    [Header("Getting Script from each object")]
    public GunScript changeHolderScriptOne;
    public GunScript changeHolderScriptTwo;

    [Header("Currency")]
    public PlayerHealth playerHealth;
    public float fireBuyAmount = 500f;
    public float dmgBuyAmount = 500f;
    private float _currency;
    
    void Start()
    {
        weaponToUpgrade = gunSwitching.currentWeapon; //current weapon inhand
        GunScript changeHolderScriptOne = weaponToUpgrade.GetComponent<GunScript>(); //references the gun script inside the gameobject for slingshot 1
        GunScript changeHolderScriptTwo = weaponToUpgrade.GetComponent<GunScript>(); //references the gun script inside the gameobject for slingshot 2
        _currency = playerHealth.currency;
    }

    // Update is called once per frame
    public void UpgradeWeaponDelay()
    {
        //check currency
        if (_currency - fireBuyAmount >= 0)
        {
            _currency -= fireBuyAmount;
            fireBuyAmount += 500;
            //upgrades the inhand weapon
            if (weaponToUpgrade.name == SlingShotOne.name)
            {
                if (changeHolderScriptOne.timeBetweenShots -0.025f >=0.1f) // validation, if delay-0.05 is greater than 0, allow to subtract
                {
                    changeHolderScriptOne.timeBetweenShots -= 0.025f; 
                }else{
                    Debug.Log("Unable to upgrade, you will have negative or no delay at all....");
                }
            
            }else{
                if (changeHolderScriptTwo.timeBetweenShots -0.025f >=0.1f)
                {
                    changeHolderScriptTwo.timeBetweenShots -= 0.025f;
                }else{
                    Debug.Log("Unable to upgrade, you will have negative or no delay at all....");
                }
            }
        }else{
            Debug.Log("You do not have enough money to upgrade your weapon delay");
        }
        
        
    }
    public void UpgradeWeaponDamage()
    {
        //check currency
        if (_currency - dmgBuyAmount >= 0)
        {  
            _currency -= dmgBuyAmount;
            dmgBuyAmount += 1000;
            if (weaponToUpgrade.name == SlingShotOne.name)
            {
                changeHolderScriptOne.damage += 15f;
            }else{
                changeHolderScriptTwo.damage += 20f;
            } 
        }else{
            Debug.Log("You do not have enough money to upgrade your weapon damage");
        }
        
    }
}