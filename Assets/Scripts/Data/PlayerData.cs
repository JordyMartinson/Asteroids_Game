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
    public int playerID;
    public float musicVol = 1f;
    public float tempMusicVol = 1f;
<<<<<<< Updated upstream
    public bool muted = false;
=======
    public float tempSFXVol = 1f;
    public bool musicMuted = false;
    public bool sfxMuted = false;
    public bool[] codes;
>>>>>>> Stashed changes

    public PlayerData(Player player) {
        this.name = player.playerName;
        this.highScore = player.highScore;
        this.timePlayed = player.timePlayed;
        this.bulletsFired = player.bulletsFired;
        this.curScore = player.curScore;
        this.curTime = player.curTime;
        // this.playerID = SaveManager.getPlayerID();
        // Debug.Log(this.curScore);
    }

    public void setSpriteNum(int num) {
        this.spriteNum = num;
    }

    public int getSpriteNum() {
        return this.spriteNum;
    }

    public void reset() {
        highScore = 0;
        timePlayed = 0;
        bulletsFired = 0;
        curScore = 0;
        curTime = 0;
    }

    public void resetSprite() {
        spriteNum = 0;
    }

    public int getPlayerID() {
        return this.playerID;
    }

    public void setMusicVol(float vol) {
        this.musicVol = vol;
    }

    public void setTempMusicVol(float vol) {
        // Debug.Log("before " + this.tempMusicVol);
        this.tempMusicVol = vol;
        // Debug.Log("after " + this.tempMusicVol);
    }

    public float getMusicVol() {
        return this.musicVol;
    }

    public float getTempMusicVol() {
        // Debug.Log("get " + this.tempMusicVol);
        return this.tempMusicVol;
    }

    public bool isMuted() {
        return this.muted;
    }

    public void muteUnmute(bool muted) {
        this.muted = muted;
    }
}
