using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profiles : MonoBehaviour
{
    public GameObject nameText;
    public InputField inField;
    private Sprite[] sprites;
    public SpriteRenderer spriteRenderer;
    private PlayerData data;
    public SettingsManager settingsManager;

    public void Awake() {
        SaveManager.profiles = SaveManager.loadProfiles();
        if(SaveManager.currentPlayer == null) {
            SaveManager.currentPlayer = (PlayerData) SaveManager.profiles[0];
        }
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();

        nameText.GetComponent<Text>().text = SaveManager.currentPlayer.name;
        spriteRenderer.sprite = sprites[SaveManager.currentPlayer.getSpriteNum()];
        settingsManager = FindObjectOfType<SettingsManager>();
    }


    public void setPNameText(PlayerData pD) {
        nameText.GetComponent<Text>().text = pD.name;
    }

    public void newPlayer() {
        Player newPlayer = new Player();
        newPlayer.playerName = inField.text;
        PlayerData pd = new PlayerData(newPlayer);
        pd.reset();
        pd.resetSprite();
        pd.setMusicVol(1f);
        pd.setSFXVol(1f);
        SaveManager.SavePlayer(pd);
        SaveManager.profiles = SaveManager.loadProfiles();
        SaveManager.currentPlayer = SaveManager.LoadPlayerByName(pd.getName());
        setPNameText(pd);
        setSprite(pd.getPlayerID());
        setNewVols();
        inField.text = "";
    }

    public void setSprite(int spriteNum) {
        spriteRenderer.sprite = sprites[spriteNum];
    }

    public void getNextPlayer() {
        // Debug.Log(SaveManager.currentPlayer.getPlayerID() + " " + SaveManager.currentPlayer.getName());
        int next = SaveManager.currentPlayer.getPlayerID() + 1;
        if(next == SaveManager.profiles.Count) {
            next = 0;
        }
        foreach (PlayerData p in SaveManager.profiles) {
            if(p.getPlayerID() == next) {
                SaveManager.currentPlayer = SaveManager.LoadPlayer(p.getPlayerID());
                
            }
        }
        setPNameText(SaveManager.currentPlayer);
        setSprite(SaveManager.currentPlayer.getSpriteNum());
        setNewVols();
        // Debug.Log(SaveManager.currentPlayer.getPlayerID() + " " + SaveManager.currentPlayer.getName());
    }

    public void getPreviousPlayer() {
        int next = SaveManager.currentPlayer.getPlayerID() - 1;
        if(next < 0) {
            next = SaveManager.profiles.Count-1;
        }
        foreach (PlayerData p in SaveManager.profiles) {
            if(p.getPlayerID() == next) {
                SaveManager.currentPlayer = SaveManager.LoadPlayer(p.getPlayerID());
            }
        }
        setPNameText(SaveManager.currentPlayer);
        setSprite(SaveManager.currentPlayer.getSpriteNum());
        setNewVols();
    }

    public void setNewVols() {
        settingsManager.setMusicVolume(SaveManager.currentPlayer.getMusicVol());
        settingsManager.setSFXVolume(SaveManager.currentPlayer.getSFXVol());
    }
}
