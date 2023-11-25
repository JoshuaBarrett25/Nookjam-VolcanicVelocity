using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralInfo : MonoBehaviour
{
    public float Score { get; private set;}
    //public float Time { get; private set; }

    // Update is called once per frame
    void Start()
    {
        Score = 1000;

        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    void Update()
    {
        // Debug.Log(GateManager.lapCount);
        //Debug.Log(Score);
        //Debug.Log(Time);
    }

    public void ScoreChange(float ScoreChangeValue)
    {
        Score += ScoreChangeValue;
    }

    //public void TimeChange(float TimeChangeValue)
    //{
        //Time += TimeChangeValue;
    //}
}
