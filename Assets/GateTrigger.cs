using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GameObject standard;
    public GameObject shortgates;
    public GameObject longgates;
    public bool Victory = false;



    private void Start()
    {
        standard.SetActive(false);
        longgates.SetActive(false);
        Victory = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (standard.active != false)
            {
                Victory = true;
            }
            else
            {
                standard.SetActive(true);
                longgates.SetActive(true);
                shortgates.SetActive(false);
                GateManager.gatesComplete = true;
            }
        }

    }
}
