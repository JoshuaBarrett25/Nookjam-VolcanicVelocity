using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GeneralInfo Timeinfo;
    private float TimeIncrease = 1;

    void Update()
    {
        float TimeChange = TimeIncrease * Time.deltaTime;
        //Timeinfo.TimeChange(TimeChange);
    }
}
