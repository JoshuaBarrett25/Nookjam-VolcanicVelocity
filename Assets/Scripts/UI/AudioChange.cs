using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChange : MonoBehaviour
{
    public Slider VolSli;
    private float newVolume;

    public void changeVolume()
    {
        newVolume = VolSli.value;
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }
    public void Start()
    {
        changeVolume();
    }
}
