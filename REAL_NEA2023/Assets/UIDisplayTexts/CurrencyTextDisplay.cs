using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class CurrencyTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI CurrencyText;
    public PlayerHealth playerHealth;
    public float currencyCheck;

    void Update()
    {
        currencyCheck = playerHealth.currency;
        CurrencyText.text = "Currency: " + currencyCheck.ToString();
    }
}
