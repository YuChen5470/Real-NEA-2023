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
        Debug.Log(weaponToUpgrade.name);
        if (weaponToUpgrade.name == SlingShotOne.name)
        {
           changeHolderScriptOne.timeBetweenShots -= 0.05f; 
        }else{
            changeHolderScriptTwo.timeBetweenShots -= 0.05f;
        }
        
    }
}
