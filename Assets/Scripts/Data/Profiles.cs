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
<<<<<<< Updated upstream
        // Debug.Log("pdname " + pd.name);
=======
        pd.setSFXVol(1f);
>>>>>>> Stashed changes
        SaveManager.SavePlayer(pd);
        setPNameText(pd);
        setSprite(pd.getPlayerID());
<<<<<<< Updated upstream
        settingsManager.setVolume(SaveManager.currentPlayer.getMusicVol());
=======
        setNewVols();
>>>>>>> Stashed changes
        SaveManager.profiles = SaveManager.loadProfiles();
    }

    public void setSprite(int spriteNum) {
        spriteRenderer.sprite = sprites[spriteNum];
    }

    public void getNextPlayer() {
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
<<<<<<< Updated upstream
        if(SaveManager.currentPlayer.isMuted()) {
            settingsManager.setVolume(SaveManager.currentPlayer.getMusicVol());
        } else {
            settingsManager.setVolume(SaveManager.currentPlayer.getTempMusicVol());
        }
=======
        setNewVols();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        if(SaveManager.currentPlayer.isMuted()) {
            settingsManager.setVolume(SaveManager.currentPlayer.getMusicVol());
        } else {
            settingsManager.setVolume(SaveManager.currentPlayer.getTempMusicVol());
        }
=======
        setNewVols();
    }

    public void setNewVols() {
        settingsManager.setMusicVolume(SaveManager.currentPlayer.getMusicVol());
        settingsManager.setSFXVolume(SaveManager.currentPlayer.getSFXVol());
>>>>>>> Stashed changes
    }
}
