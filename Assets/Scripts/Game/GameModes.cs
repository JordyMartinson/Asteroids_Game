using UnityEngine;
using UnityEngine.UI;

public class GameModes : MonoBehaviour
{
    [SerializeField] private Toggle[] toggles = new Toggle[numModes];
    public static int numModes = 3;
    private PlayerData pD;

    private void Start() {
        pD = SaveManager.currentPlayer;
        resetModes();
    }

    public void resetModes() {
        pD = SaveManager.currentPlayer;
        for(int i = 0; i < numModes; i++) {
            toggles[i].isOn = false;
            pD.setMode(i, false);
        }
    }

    // Method to stop pacifist and random shooting both being on
    private void modeOn(int i) {
        pD.setMode(i, toggles[i].isOn);
        if(i == 0 && toggles[i].isOn) {
            toggles[1].interactable = false;
        } else if(i == 1 && toggles[i].isOn) {
            toggles[0].interactable = false;
        } else if(!toggles[0].isOn && !toggles[1].isOn) {
            toggles[0].interactable = true;
            toggles[1].interactable = true;
        }
        SaveManager.SavePlayer(pD);
    }
}
