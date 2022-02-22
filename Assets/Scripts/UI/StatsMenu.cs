using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    public Text highScoreText;
    public Text timePlayedText;
    public Text bulletsFiredText;

    private int highScore;

    private int minuteDiv = 60;
    private int timeMins;
    private int timeSecs;
    private string minsText = "minutes";
    private string secsText = "seconds";

    private int bulletsFired;

    IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        SetStats();
    }

    public void SetStats() {
        timeMins = PlayerPrefs.GetInt("timePlayed") / minuteDiv;
        timeSecs = PlayerPrefs.GetInt("timePlayed") % minuteDiv;
        highScore = PlayerPrefs.GetInt("highScore");
        bulletsFired = PlayerPrefs.GetInt("bulletsFired");

        highScoreText.text = string.Format("High Score: {0} points", highScore);

        if (timeMins == 1) {
            minsText = "minute";
        }

        if (timeSecs == 1) {
            secsText = "second";
        }

        if (timeMins == 0) {
            timePlayedText.text = string.Format("Time Played: {0} {1}",
                timeSecs, secsText);
        } else {
            timePlayedText.text = string.Format("Time Played: {0} {1} {2} {3}",
                timeMins, minsText, timeSecs, secsText);
        }

        bulletsFiredText.text = string.Format("Bullets Fired: {0}", PlayerPrefs.GetInt("bulletsFired"));
    }
}
