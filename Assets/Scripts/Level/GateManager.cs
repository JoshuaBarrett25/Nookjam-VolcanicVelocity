using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public GameObject shortLap;
    public GameObject longLap;
    DetourTrigger detourTrigger;

    public static bool gatesComplete;

    public static int lapCount;

    private void Start()
    {
        shortLap.SetActive(true);
        longLap.SetActive(false);
        lapCount = 0;
    }


    private void Update()
    {
        if (lapCount == 0)
        {
            longLap.SetActive(false);
            shortLap.SetActive(true);
        }

        if (lapCount == 1)
        {
            if (DetourTrigger.detour)
            {
                shortLap.SetActive(false);
                longLap.SetActive(true);
            }
            if (!DetourTrigger.detour)
            {
                longLap.SetActive(false);
                shortLap.SetActive(true);
            }
        }

        if (lapCount >= 2)
        {
            longLap.SetActive(true);
            shortLap.SetActive(false);
        }
    }
}
