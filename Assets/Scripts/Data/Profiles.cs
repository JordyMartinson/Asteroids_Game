using UnityEngine;
using UnityEngine.UI;

public class Profiles : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject nameText;
    [SerializeField] private InputField inField;
    private SettingsManager settingsManager;
    private Sprite[] sprites;
    
    public void Awake() {
        SaveManager.profiles = SaveManager.loadProfiles();
        if(SaveManager.currentPlayer == null) {
            SaveManager.currentPlayer = (PlayerData) SaveManager.profiles[0];
        }
        settingsManager = FindObjectOfType<SettingsManager>();
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer.sprite = sprites[SaveManager.currentPlayer.getSpriteNum()];
        nameText.GetComponent<Text>().text = SaveManager.currentPlayer.name;
    }

    private void setPNameText(PlayerData pD) {
        nameText.GetComponent<Text>().text = pD.name;
    }

    private void newPlayer() {
        Player newPlayer = new Player();
        newPlayer.setName(inField.text);
        PlayerData newPD = new PlayerData(newPlayer);
        newPD.reset();
        newPD.resetSprite();
        newPD.setMusicVol(1f);
        newPD.setSFXVol(1f);
        SaveManager.SavePlayer(newPD);
        SaveManager.profiles = SaveManager.loadProfiles();
        SaveManager.currentPlayer = SaveManager.LoadPlayerByName(newPD.getName());
        setPNameText(newPD);
        setSprite(newPD.getPlayerID());
        setNewVols();
        inField.text = "";
    }

    private void setSprite(int spriteNum) {
        spriteRenderer.sprite = sprites[spriteNum];
    }

    private void getNextPlayer() {
        int next = SaveManager.currentPlayer.getPlayerID() + 1;
        if(next == SaveManager.profiles.Count) {
            next = 0;
        }
        foreach (PlayerData pd in SaveManager.profiles) {
            if(pd.getPlayerID() == next) {
                SaveManager.currentPlayer = SaveManager.LoadPlayer(pd.getPlayerID());
            }
        }
        setPNameText(SaveManager.currentPlayer);
        setSprite(SaveManager.currentPlayer.getSpriteNum());
        setNewVols();
    }

    private void getPreviousPlayer() {
        int next = SaveManager.currentPlayer.getPlayerID() - 1;
        if(next < 0) {
            next = SaveManager.profiles.Count-1;
        }
        foreach (PlayerData pd in SaveManager.profiles) {
            if(pd.getPlayerID() == next) {
                SaveManager.currentPlayer = SaveManager.LoadPlayer(pd.getPlayerID());
            }
        }
        setPNameText(SaveManager.currentPlayer);
        setSprite(SaveManager.currentPlayer.getSpriteNum());
        setNewVols();
    }

    private void setNewVols() {
        settingsManager.setMusicVolume(SaveManager.currentPlayer.getMusicVol());
        settingsManager.setSFXVolume(SaveManager.currentPlayer.getSFXVol());
    }
}
