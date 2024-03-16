using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageCost : MonoBehaviour
{
    public TextMeshProUGUI DamageCostText;
    public DamageFireRate damageFireRate;
    public float damageCost;
    void Update()
    {
        damageCost = damageFireRate.dmgBuyAmount;
        DamageCostText.text = "Cost: " + damageCost.ToString();
    }
}
