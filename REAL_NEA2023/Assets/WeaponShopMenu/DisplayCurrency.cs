using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCurrency : MonoBehaviour
{
    public DamageFireRate damageFireRate;
    public TextMeshProUGUI currencyText;
    private float currency;
    // Update is called once per frame
    void Update()
    {
        currency = damageFireRate._currency;
        currencyText.text = "Currency: " + currency.ToString();
    }
}
