using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text timePlayedText;
    [SerializeField] private Text bulletsFiredText;
    private int highScore;
    private int timeMins;
    private int timeSecs;
    private int bulletsFired;
    private string minsText = "minutes";
    private string secsText = "seconds";
    private int minuteDiv = 60;

    private IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        SetStats();
    }

    private void SetStats() {
        timeMins = SaveManager.currentPlayer.timePlayed / minuteDiv;
        timeSecs = SaveManager.currentPlayer.timePlayed % minuteDiv;
        highScore = SaveManager.currentPlayer.highScore;
        bulletsFired = SaveManager.currentPlayer.bulletsFired;

        highScoreText.text = string.Format("High Score:{0}{1} points", Environment.NewLine, highScore);

        if (timeMins == 1) {
            minsText = "minute";
        }
        if (timeSecs == 1) {
            secsText = "second";
        }
        if (timeMins == 0) {
            timePlayedText.text = string.Format("Time Played:{0}{1} {2}",
                Environment.NewLine, timeSecs, secsText);
        } else {
            timePlayedText.text = string.Format("Time Played:{0}{1} {2} {3} {4}",
                Environment.NewLine, timeMins, minsText, timeSecs, secsText);
        }

        bulletsFiredText.text = string.Format("Bullets Fired:{0}{1}", Environment.NewLine, bulletsFired);
    }
}
