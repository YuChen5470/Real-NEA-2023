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

    void Start()
    {
        weaponToUpgrade = gunSwitching.currentWeapon; //current weapon inhand
        GunScript changeHolderScriptOne = weaponToUpgrade.GetComponent<GunScript>(); //references the gun script inside the gameobject for slingshot 1
        GunScript changeHolderScriptTwo = weaponToUpgrade.GetComponent<GunScript>(); //references the gun script inside the gameobject for slingshot 2
    }

    // Update is called once per frame
    public void UpgradeWeaponDelay()
    {
        //check currency

        //upgrades the inhand weapon
        if (weaponToUpgrade.name == SlingShotOne.name)
        {
            if (changeHolderScriptOne.timeBetweenShots -0.05f >0) // validation, if delay-0.05 is greater than 0, allow to subtract
            {
                changeHolderScriptOne.timeBetweenShots -= 0.05f; 
            }else{
                Debug.Log("Unable to upgrade, you will have negative or no delay at all....");
            }
           
        }else{
            if (changeHolderScriptTwo.timeBetweenShots -0.05f >0)
            {
                changeHolderScriptTwo.timeBetweenShots -= 0.05f;
            }else{
                Debug.Log("Unable to upgrade, you will have negative or no delay at all....");
            }
        }
        
    }
    public void UpgradeWeaponDamage()
    {
        //check currency

        if (weaponToUpgrade.name == SlingShotOne.name)
        {
            changeHolderScriptOne.damage += 50f;
        }else{
            changeHolderScriptTwo.damage += 50f;
        }
    }
}