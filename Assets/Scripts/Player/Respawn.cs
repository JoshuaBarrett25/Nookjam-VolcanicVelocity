using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public RespawnManager manager;
    public UIScript timer;

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            manager.Crash();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            manager.Crash();
        }
        else if (other.gameObject.tag == "Spawn")
        {
            manager.changeCoord(other.gameObject.transform.position, other.gameObject.transform.rotation);
            // timer.ChangeTime(-5);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            manager.Crash();

        }
    }
}
