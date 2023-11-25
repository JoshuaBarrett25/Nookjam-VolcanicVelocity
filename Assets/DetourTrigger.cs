using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetourTrigger : MonoBehaviour
{
    public TextMeshPro Text;
    public GameObject Chevrons;
    public static bool detour = false;

    private void Update()
    {
        if (GateManager.lapCount == 1)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Text.SetText("ROAD AHEAD " + '\n' +
                "    CLOSED");
            Chevrons.SetActive(true);
            detour = true;
        }
    }
}
