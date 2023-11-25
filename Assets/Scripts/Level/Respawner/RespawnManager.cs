using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class RespawnManager : MonoBehaviour
{
    public GameObject player;
    public CarMovement carMovement;
    public Transform defaultSpawn;
    static public Transform currentRespawnPoint;
    public GeneralInfo generalInfo;

    public float respawnTime = 3.0f;
    private int countdown = 3;
    private Vector3 respawnPoint;
    private Quaternion respawnRot;

    private void Awake()
    {
        player.gameObject.SetActive(true);
        currentRespawnPoint = defaultSpawn;
        

        respawnPoint = carMovement.gameObject.transform.position;
        respawnRot = carMovement.gameObject.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Cancel") != 0 && carMovement.controlsEnabled != false)
        {
            Crash();
        }
    }

    public void changeCoord(Vector3 pos, Quaternion rot)
    {
        respawnPoint = pos;
        respawnRot = rot;
    }

    public async void Crash()
    {
        player.gameObject.SetActive(false);
        generalInfo.ScoreChange(-100);
        carMovement.gameObject.transform.position = respawnPoint;
        carMovement.gameObject.transform.rotation = respawnRot;
        player.gameObject.SetActive(true);
        carMovement.controlsEnabled = false;

        await Task.Delay(countdown * 1000);
        carMovement.controlsEnabled = true;
    }
}
