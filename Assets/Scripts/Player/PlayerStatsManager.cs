using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public void AddTimeToTotal() {
        PlayerPrefs.SetInt("timePlayed", (PlayerPrefs.GetInt("timePlayed") + (int)FindObjectOfType<GameManager>().t));
    }
}
