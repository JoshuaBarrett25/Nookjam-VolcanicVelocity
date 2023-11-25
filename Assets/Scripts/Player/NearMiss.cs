using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearMiss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Score.
        }
    }
}
