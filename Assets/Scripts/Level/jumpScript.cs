using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    public Rigidbody player;
    bool gravityDisabled;
    float countdown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.useGravity = false;
            gravityDisabled = true;
        }
    }

    private void Update()
    {
        if (gravityDisabled)
        {
            countdown += Time.deltaTime;
            if (countdown >= 0.4f)
            {
                player.useGravity = true;
                gravityDisabled = false;
                countdown = 0;
            }
        }    
    }
}
