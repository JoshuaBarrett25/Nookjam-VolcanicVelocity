using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBlockShortLap : MonoBehaviour
{
    public Animator rockBShortLap;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rockBShortLap.SetBool("Trigger", true);
        }    
    }
}
