using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecord : MonoBehaviour
{
    public GhostLap ghost;
    private float timeValue;
    private int index1;
    private int index2;
    public bool change = true;
    private void Awake()

    { 
        timeValue = 0;
    }

    void Update()
    {
        timeValue += Time.unscaledDeltaTime;

        if (ghost.isReplay)
        {
            //Debug.Log(timeValue);
            if (change == true)
            {
                timeValue = 2;
                //ghost.TimePos.Clear();
                //Debug.Log(timeValue);
                change = false;
            }
            GetIndex();
            SetTransform();
        }
    }
    private void GetIndex()
    {
        for (int i = 0; i < ghost.TimePos.Count - 2; i++)
        {
            if (ghost.TimePos[i] == timeValue)
            {
                index1 = i;
                index2 = i;
                return;
            }
            else if (ghost.TimePos[i] < timeValue & timeValue < ghost.TimePos[i + 1])
            {
                index1 = i;
                index2 = i + 1;
                return;
            }
        }
        index1 = ghost.TimePos.Count - 1;
        index2 = ghost.TimePos.Count - 1;
    }
    private void SetTransform()
    {
        if (index1 == index2)
        {
            this.transform.position = ghost.Position[index1];
            this.transform.rotation = ghost.Rotation[index1];
        }
        else
        {
            float interpolationFactor = (timeValue - ghost.TimePos[index1]) / (ghost.TimePos[index2] - ghost.TimePos[index1]);
            this.transform.position = Vector3.Lerp(ghost.Position[index1], ghost.Position[index2], interpolationFactor);
            this.transform.rotation = Quaternion.Slerp(ghost.Rotation[index1], ghost.Rotation[index2], interpolationFactor);
        }
    }
}
