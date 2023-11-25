using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscoreSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int highscore = PlayerPrefs.GetInt("Highscore" + 1, 0);
        // Check if highscores are already set in PlayerPrefs
        if (highscore == 0)
        {
            PlayerPrefs.SetInt("Highscore" + 0, 500);
            PlayerPrefs.SetInt("Highscore" + 1, 600);
            PlayerPrefs.SetInt("Highscore" + 2, 800);
            PlayerPrefs.SetInt("Highscore" + 3, 1000);
            PlayerPrefs.SetInt("Highscore" + 4, 1200);
            PlayerPrefs.Save();
        }
    }

}
