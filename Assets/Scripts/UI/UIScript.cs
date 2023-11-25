using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text timeText;
    public Text speedText;
    public Text scoreText;
    public GeneralInfo generalInfo;
    public GameObject car;
    public CarMovement carMovement;
    private int minutes;
    private float timecheck;
    private float timesecs;
    public int time;

    [Tooltip("List of all the lap gates in the scene. Assign in chronological order of lap gates")]
    public List<GameObject> lapGates;
    private static List<GameObject> _lapGates;
    [SerializeField] private GameObject _arrow;
    public static GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTime());

        _lapGates = lapGates;
        Arrow = _arrow;

        Vector3 newPos = new Vector3(_lapGates[0].transform.position.x, _lapGates[0].transform.position.y + 4, _lapGates[0].transform.position.z);
        Arrow.transform.position = newPos;
    }

    /*public static void ClearStaticData()
    {
        _lapGates = null;
        Arrow = null;
    }*/

    IEnumerator UpdateTime()
    {
        while (true)
        {
            timecheck += 1;
            time += 1;
            timeText.text = minutes + " : " + timecheck.ToString();
            //Debug.Log(timecheck);
            if (Mathf.RoundToInt(timecheck) > 59)
            {
                timecheck = 0;
                minutes++;
            }

            yield return new WaitForSeconds(1);
        }
    }

    public static void RemoveCurrentGate()
    {
        _lapGates.RemoveAt(0);

        if (_lapGates.Count == 0)
        {
            return;
        }

        Vector3 newPos = new Vector3(_lapGates[0].transform.position.x, _lapGates[0].transform.position.y + 4, _lapGates[0].transform.position.z);
        Arrow.transform.position = newPos;
    }

    //public void ChangeTime(int seconds)
    //{
    //timeAlter -= seconds;
    //}

    void Update()
    {
        // Vector3 lastPosition = car.transform.position;
        speedText.text = Mathf.RoundToInt(carMovement.currentSpeed) + " MPH";
        scoreText.text = ("Score " + Mathf.RoundToInt(generalInfo.Score));

        Arrow.transform.LookAt(car.transform.position);
    }
}

