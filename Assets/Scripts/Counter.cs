using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    public int count;

    private void Start()
    {
        count = 0;
        CounterText.text = "Score: 0"; 
    }

    private void OnTriggerEnter(Collider other)
    {
        count += 1;
        CounterText.text = "Score : " + count;
    }
}
