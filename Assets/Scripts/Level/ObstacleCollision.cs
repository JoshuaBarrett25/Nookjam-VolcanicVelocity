using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    GameObject manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GateManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        manager.GetComponent<RespawnManager>().Crash();
    }
}
