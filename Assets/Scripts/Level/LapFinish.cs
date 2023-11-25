using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LapFinish : MonoBehaviour
{
    public GhostLap ghost;
    public int[] highscores = new int[5];
    public GateTrigger GateTrigger;
    public UIScript UIScript;

    private void Start()
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            highscores[i] = PlayerPrefs.GetInt("Highscore" + i, 0);
        }
    }

    public void CheckAndUpdateHighscore(int timer)
    {
        for (int i = 0; i < highscores.Length; i++)
        {
            if (timer < highscores[i])
            {
                for (int j = highscores.Length - 1; j > i; j--)
                {
                    highscores[j] = highscores[j - 1];
                }

                highscores[i] = timer;

                break; 
            }
        }

        for (int i = 0; i < highscores.Length; i++)
        {
            PlayerPrefs.SetInt("Highscore" + i, highscores[i]);
        }
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            ghost.IsRecord = false;
            ghost.isReplay = true;
            if(GateTrigger.Victory != false)
            {
                Debug.Log("victory");
                CheckAndUpdateHighscore(UIScript.time);
                for (int i = 0; i < highscores.Length; i++)
                {
                    PlayerPrefs.SetInt("Highscore" + i, highscores[i]);
                    Debug.Log(highscores[i]);
                }
                PlayerPrefs.Save();
                SceneManager.LoadScene(2);
            }
            else if (GateManager.gatesComplete)
            {
                GateManager.lapCount += 1;
                GateManager.gatesComplete = false;
            }
        }
    }
}
