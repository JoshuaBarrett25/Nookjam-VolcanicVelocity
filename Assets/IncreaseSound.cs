using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSound : MonoBehaviour
{
    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        m_AudioSource.volume = 4f;
    }
}
