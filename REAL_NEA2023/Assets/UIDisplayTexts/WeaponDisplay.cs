using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class WeaponDisplay : MonoBehaviour
{
    public TextMeshProUGUI WeaponText;
    public GameObject slingShot1;
    public GameObject slingShot2;
    public string WeaponCheck;

    void Update()
    {
        if (slingShot1.activeSelf)
        {
            WeaponCheck = "SlingShot1";
        }else{
            WeaponCheck = "SlingShot2";
        
        }
        WeaponText.text = "Weapon: " + WeaponCheck;
    }
}
