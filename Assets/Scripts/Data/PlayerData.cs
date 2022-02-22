using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public string name;
    public int highScore;
    public int bulletsFired;

    public PlayerData(string name, int highScore, int bulletsFired) {
        this.name = name;
        this.highScore = highScore;
        this.bulletsFired = bulletsFired;
    }

    public override string ToString() {
        return $"{name}: High Score - {highScore}   Bullets Fired - {bulletsFired}";
    }
}
