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
    // private static idCount = 0;
    // public PlayerData[] profiles;
    public SettingsManager settingsManager;



    public void Awake() {
        SaveManager.profiles = SaveManager.loadProfiles();
        if(SaveManager.currentPlayer == null) {
            SaveManager.currentPlayer = (PlayerData) SaveManager.profiles[0];
        }
        // Debug.Log(SaveManager.profiles[0].name);
        // profiles = SaveManager.profiles;
        // Debug.Log(profiles[0].name);
        // if(SaveManager.LoadPlayer(0) != null) {
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();

        nameText.GetComponent<Text>().text = SaveManager.currentPlayer.name;
        spriteRenderer.sprite = sprites[SaveManager.currentPlayer.getSpriteNum()];
        settingsManager = FindObjectOfType<SettingsManager>();
        // } else {
        //     nameText.GetComponent<Text>().text = "CREATE NEW SAVE";
        // }
    }

    // IEnumerator Start() {
    //     yield return new WaitForSeconds(0.1f);
    //     // playerData = SaveManager.LoadPlayer();

        
    // }

    public void setPNameText(PlayerData pD) {
        // PlayerData data = SaveManager.LoadPlayer(pD.getPlayerID());
        // Debug.Log(data.name);
        nameText.GetComponent<Text>().text = pD.name;
    }

    public void newPlayer() {
        Player newPlayer = new Player();
        newPlayer.playerName = inField.text;
        // Debug.Log("newplayer " + newPlayer.playerName);
        PlayerData pd = new PlayerData(newPlayer);
        pd.reset();
        pd.resetSprite();
        pd.setMusicVol(1f);
        // Debug.Log("pdname " + pd.name);
        SaveManager.SavePlayer(pd);
        setPNameText(pd);
        // Debug.Log(pd.getPlayerID());
        setSprite(pd.getPlayerID());
        settingsManager.setVolume(SaveManager.currentPlayer.getMusicVol());
        SaveManager.profiles = SaveManager.loadProfiles();
        // SaveManager.currentPlayer = SaveManager.LoadPlayer()
    }

    public void setSprite(int spriteNum) {
        // string name = profiles[id].name;
        // Debug.Log(data.name);
        // data = SaveManager.LoadPlayer(id);
        // Debug.Log(data.name);
        // Debug.Log(playerData.name);
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
        if(SaveManager.currentPlayer.isMuted()) {
            settingsManager.setVolume(SaveManager.currentPlayer.getMusicVol());
        } else {
            settingsManager.setVolume(SaveManager.currentPlayer.getTempMusicVol());
        }
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
        if(SaveManager.currentPlayer.isMuted()) {
            settingsManager.setVolume(SaveManager.currentPlayer.getMusicVol());
        } else {
            settingsManager.setVolume(SaveManager.currentPlayer.getTempMusicVol());
        }
    }
}
