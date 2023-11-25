using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{

    public TextMeshProUGUI[] highscoreTexts;

    private void Start()
    {
        // Load the highscores from PlayerPrefs and display them
        for (int i = 0; i < highscoreTexts.Length; i++)
        {
            int highscore = PlayerPrefs.GetInt("Highscore" + i, 0);
            string highscoreFormatted = FormatTime(highscore);
            highscoreTexts[i].text = "Highscore " + (i + 1) + ": " + highscoreFormatted;
        }
    }

    private string FormatTime(int timeInSeconds)
    {
        int minutes = timeInSeconds / 60;
        int seconds = timeInSeconds % 60;
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
