using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireRateCost : MonoBehaviour
{
    public TextMeshProUGUI FireRateCostText;
    public DamageFireRate damageFireRate;
    public float fireRateCost;
   

    void Update()
    {
        fireRateCost = damageFireRate.fireBuyAmount;
        FireRateCostText.text = "Cost: " + fireRateCost.ToString();
    }
}
