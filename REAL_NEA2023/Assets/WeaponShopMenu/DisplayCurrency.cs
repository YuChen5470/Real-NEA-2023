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
    void Start()
    {
        _currency = playerHealth.currency;
    }
    void Update()
    {
        currencyText.text = "Currency: " + _currency.ToString();
    }
}
