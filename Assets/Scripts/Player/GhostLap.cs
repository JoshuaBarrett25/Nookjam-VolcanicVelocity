using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GhostLap : ScriptableObject
{
    public bool IsRecord;
    public bool isReplay;
    public float RecondFrequency;

    public List<float> TimePos;
    public List<Vector3> Position;
    public List<Quaternion> Rotation;

    public void LapReset()
    {
        TimePos.Clear();
        Position.Clear();
        Rotation.Clear();
    }
}
