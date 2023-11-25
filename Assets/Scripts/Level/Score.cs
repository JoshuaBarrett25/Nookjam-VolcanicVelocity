using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public GeneralInfo Scoreinfo;
    private float ScoreIncrease = 1;
    private int time = 100;

    void Update()
    {
        float ScoreChange = ScoreIncrease * Time.deltaTime;
        Scoreinfo.ScoreChange(ScoreChange);
    }
}
