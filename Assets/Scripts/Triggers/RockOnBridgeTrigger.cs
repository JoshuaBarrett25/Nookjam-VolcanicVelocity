using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOnBridgeTrigger : MonoBehaviour
{
    public Animator RockAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RockAnimator.SetBool("Trigger", true);
        }
    }
}
