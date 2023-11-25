using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public GhostLap ghost;
    // Start is called before the first frame update
    void Start()
    {
        ghost.LapReset();
        ghost.IsRecord = true;
        ghost.isReplay = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
