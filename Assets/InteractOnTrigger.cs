using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractOnTrigger : MonoBehaviour
{
    /*[Header("Delete")]
    public GameObject[] toBeDeleted;

    [Header("Enable")]
    public GameObject[] toBeEnabled;*/

    [SerializeField] private bool _destroyOnTrigger = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        /*for (int i = 0; i < toBeDeleted.Length; i++)
        {
            Destroy(toBeDeleted[i]);
        }

        for (int i = 0; i < toBeEnabled.Length; i++)
        {
            toBeEnabled[i].SetActive(true);
        }*/

        UIScript.RemoveCurrentGate();

        if (_destroyOnTrigger)
        {
            Destroy(this);
        }
        else
        {
            _destroyOnTrigger = true;
        }
    }
}
