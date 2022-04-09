using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int highScore;
    public int timePlayed;
    public int bulletsFired;
    public int spriteNum;
    public int curScore;
    public float curTime;

    public PlayerData(Player player) {
        this.name = player.playerName;
        this.highScore = player.highScore;
        this.timePlayed = player.timePlayed;
        this.bulletsFired = player.bulletsFired;
        this.curScore = player.curScore;
        this.curTime = player.curTime;
        // Debug.Log(this.curScore);
    }

    public void setSpriteNum(int num) {
        this.spriteNum = num;
    }

    public int getSpriteNum() {
        return this.spriteNum;
    }

    public void reset() {
        curScore = 0;
        curTime = 0;
    }
}
