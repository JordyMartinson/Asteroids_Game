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
    public int playerID;
    public float curTime;
    public float musicVol = 1f;
    public float sfxVol = 1f;
    public float tempMusicVol = 1f;
    public float tempSFXVol = 1f;
    public bool musicMuted = false;
    public bool sfxMuted = false;
    public bool[] codes = new bool[AchievementsSuper.numAchs];
    public bool[] gameModes = new bool[GameModes.numModes];

    public PlayerData(Player player) {
        this.name = player.playerName;
        this.highScore = player.highScore;
        this.timePlayed = player.timePlayed;
        this.bulletsFired = player.bulletsFired;
        this.curScore = player.curScore;
        this.curTime = player.curTime;
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

    public bool[] getCodes() {
        return this.codes;
    }

    public void setCode(int i) {
        this.codes[i] = true;
    }

    public bool[] getModes() {
        return this.gameModes;
    }

    public void setMode(int i, bool onOff) {
        this.gameModes[i] = onOff;
    }

    public void setSpriteNum(int num) {
        this.spriteNum = num;
    }

    public int getSpriteNum() {
        return this.spriteNum;
    }

    public void setPlayerID(int id) {
        this.playerID = id;
    }

    public int getPlayerID() {
        return this.playerID;
    }

    public void setMusicVol(float vol) {
        this.musicVol = vol;
    }

    public void setTempMusicVol(float vol) {
        this.tempMusicVol = vol;
    }

    public float getMusicVol() {
        return this.musicVol;
    }

    public float getTempMusicVol() {
        return this.tempMusicVol;
    }

    public bool isMusicMuted() {
        return this.musicMuted;
    }

    public void musicMuteUnmute(bool muted) {
        this.musicMuted = muted;
    }

    public void setSFXVol(float vol) {
        this.sfxVol = vol;
    }

    public void setTempSFXVol(float vol) {
        this.tempSFXVol = vol;
    }

    public float getSFXVol() {
        return this.sfxVol;
    }

    public float getTempSFXVol() {
        return this.tempSFXVol;
    }

    public bool isSFXMuted() {
        return this.sfxMuted;
    }

    public void sfxMuteUnmute(bool muted) {
        this.sfxMuted = muted;
    }

    public string getName() {
        return this.name;
    }

    public void setBulletsFired(int setBullets) {
        this.bulletsFired = setBullets;
    }
}
