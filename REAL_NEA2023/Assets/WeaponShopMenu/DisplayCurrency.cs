using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrency : MonoBehaviour
{
    public PlayerHealth playerHealth;

    public TextMeshProUGUI currencyText;
    private float _currency;
    // Update is called once per frame
    void Update()
    {
        _currency = playerHealth.currency;
        currencyText.text = "Currency: " + _currency.ToString();
    }
}
