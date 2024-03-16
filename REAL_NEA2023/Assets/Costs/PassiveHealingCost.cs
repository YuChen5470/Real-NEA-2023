using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PassiveHealingCost : MonoBehaviour
{
   public TextMeshProUGUI PassHealthText;
   public GeneralDefence generalDefence;
   public float passHealthCost;

   void Update()
   {
    passHealthCost = generalDefence.pashpBuyAmount;
    PassHealthText.text = "Cost: " + passHealthCost.ToString();
   }
}
