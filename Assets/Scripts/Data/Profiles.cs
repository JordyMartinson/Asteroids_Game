using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profiles : MonoBehaviour
{
    public GameObject nameText;
    public InputField inField;

    public void Awake() {
        if(SaveManager.LoadPlayer() != null) {
            PlayerData data = SaveManager.LoadPlayer();
            nameText.GetComponent<Text>().text = data.name;
        } else {
            nameText.GetComponent<Text>().text = "CREATE NEW SAVE";
        }
    }

    public void getPlayerName() {
        PlayerData data = SaveManager.LoadPlayer();
        nameText.GetComponent<Text>().text = data.name;
    }

    public void newPlayer() {
        Player newPlayer = new Player();
        newPlayer.playerName = inField.text;
        PlayerData pd = new PlayerData(newPlayer);
        SaveManager.SavePlayer(pd);
    }
}
