using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaving : MonoBehaviour
{
    private PlayerData playerData;

    public void Awake() {
        PlayerPrefs.DeleteAll(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerData();
    }

    private void CreatePlayerData() {
        playerData = new PlayerData("Default", 0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            LoadData();
        }
    }

    public void SaveData() {
        PlayerPrefs.SetString("name", playerData.name);
        PlayerPrefs.SetInt("highScore", playerData.highScore);
        PlayerPrefs.SetInt("bulletsFired", playerData.bulletsFired);
    }

    public void LoadData() {
        playerData = new PlayerData(PlayerPrefs.GetString("name"), PlayerPrefs.GetInt("highScore"), PlayerPrefs.GetInt("bulletsFired"));

        Debug.Log(playerData.ToString());
    }
}
