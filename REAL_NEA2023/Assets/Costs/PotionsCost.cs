using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PotionsCost : MonoBehaviour
{
    public TextMeshProUGUI PotionsCostText;
    public GeneralDefence generalDefence;
    public float potionsCost;

    void Update()
    {
        potionsCost = generalDefence.ptnsBuyAmount;
        PotionsCostText.text = "Cost: " + potionsCost.ToString();
    }
}
