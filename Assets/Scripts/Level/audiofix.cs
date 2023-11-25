using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiofix : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Debug.Log(audioSource.isPlaying);
        audioSource.Play();
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        audioSource.volume = 1;
        Debug.Log(PlayerPrefs.GetFloat("volume"));
        Debug.Log(audioSource.isPlaying);
    }

}
