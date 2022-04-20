using System;
using System.IO;
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

    // private PlayerData data;

    IEnumerator Start() {
        // Debug.Log("started");
        yield return new WaitForSeconds(0.1f);
        // if(SaveManager.currentPlayer != null) { //change to current player
        //     data = SaveManager.LoadPlayer(0); //change to current player
        // } else {
        //     Debug.Log("prompt new save");
        // }
        // Debug.Log(data.name);
        // Debug.Log(data.highScore);
        SetStats();
    }

    

    public void SetStats() {
        timeMins = SaveManager.currentPlayer.timePlayed / minuteDiv;
        timeSecs = SaveManager.currentPlayer.timePlayed % minuteDiv;
        highScore = SaveManager.currentPlayer.highScore;
        bulletsFired = SaveManager.currentPlayer.bulletsFired;
        // Debug.Log(highScore);
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
