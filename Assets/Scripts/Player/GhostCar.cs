using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCar : MonoBehaviour
{
    public GhostLap ghost;
    private float timer;
    private float timevalue;

    private void Awake()
    {
        if(ghost.IsRecord)
        {
            ghost.LapReset();
            timer = 0; timevalue = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        timevalue += Time.unscaledDeltaTime;

        if(ghost.IsRecord && timer >= 1/ghost.RecondFrequency)
        {
            ghost.TimePos.Add(timevalue);
            ghost.Position.Add(this.transform.position);
            ghost.Rotation.Add(this.transform.rotation);

            timer = 0;
        }
    }
}
