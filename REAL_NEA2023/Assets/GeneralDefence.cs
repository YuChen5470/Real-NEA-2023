using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralDefence : MonoBehaviour
{
    [Header("Currency")]
    public PlayerHealth playerHealth;
    public float ptnsBuyAmount = 500f;
    public float pashpBuyAmount = 500f;
    private float _currency;
    void Start()
    {
        _currency = playerHealth.currency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
