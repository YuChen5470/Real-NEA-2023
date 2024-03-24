using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class BulletDisplay : MonoBehaviour
{
    public TextMeshProUGUI BulletsText;
    public GunScript gunOneScript;
    public GunScript gunTwoScript;
    public GameObject slingShot1;
    public GameObject slingShot2;
    public float BulletsCheck;


    void Update()
    {
        if (slingShot1.activeSelf)
        {
            BulletsCheck = gunOneScript.currentBullets;
        }else{
            BulletsCheck = gunTwoScript.currentBullets;
        
        }
        BulletsText.text = "Bullets " + BulletsCheck.ToString();
    }
}
