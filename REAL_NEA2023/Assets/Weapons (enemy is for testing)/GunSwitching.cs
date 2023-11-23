using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitching : MonoBehaviour
{
    public GameObject[] weapons = new GameObject[2]; //sets an array of size 2 called weapons
    private int inhandWeapon = 0;
    public GameObject currentWeapon;

    void Start()
    {
        SelectWeapon(inhandWeapon); // at the start, the user will always have the first weapon in hand.
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            inhandWeapon = 0;
            SelectWeapon(inhandWeapon); // enables the first weapons component
        }
        else if (Input.GetKeyDown("2"))
        {
            inhandWeapon = 1;
            SelectWeapon(inhandWeapon); // enables the second weapon component
        }
    }

    void SelectWeapon(int index)//takes in the index of the weapon, which is in the array
    {   
        foreach (GameObject weapon in weapons) //loops through the whole list of 2
        {
            if(weapons != null) // if the weapon is not already turned off it will turn it off.
            {
                weapon.SetActive(false);
            }
        }

        if (weapons[index] != null) //in any case where there is no weapon active,
        {
            weapons[index].SetActive(true);
            currentWeapon = weapons[index];
        }
    } 
}




/*
public GameObject weaponOne, weaponTwo;
    void Start()
    {
        GameObject weaponOne = GameObject.Find("SlingShot1"); //looks for the slingshot1/2
        GameObject weaponTwo = GameObject.Find("SlingShot2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            weaponOne.SetActive(true);
            weaponTwo.SetActive(false);
        }else if (Input.GetKeyDown("2")){
            weaponOne.SetActive(false);
            weaponTwo.SetActive(true);
        }   
    }

*/