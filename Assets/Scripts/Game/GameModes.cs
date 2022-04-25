using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModes : MonoBehaviour
{
    public PlayerData pd;
    public static int numModes = 3;

    // public Toggle pacifistToggle;
    // public Toggle randomToggle;
    // public Toggle forwardToggle;
    public Toggle[] toggles = new Toggle[numModes];

    public void Start() {
        pd = SaveManager.currentPlayer;
        // Debug.Log(pd.getModes());
        resetModes();
    }

    // IEnumerator Start() {
    //     yield return new WaitForSeconds(0.1f);
    //     SetAchieved();
    // }

    public void resetModes() {
        // pacifistToggle.isOn = false;
        // randomToggle.isOn = false;
        // forwardToggle.isOn = false;
        // Debug.Log("current " + pd.name);
        pd = SaveManager.currentPlayer;
        // Debug.Log("current " + pd.name);
        for(int i = 0; i < numModes; i++) {
            // Debug.Log("toggle " + i + " " + SaveManager.currentPlayer.getModes()[i]);
            toggles[i].isOn = false;
            pd.setMode(i, false);
            // Debug.Log("toggle " + i + " " + SaveManager.currentPlayer.getModes()[i]);
        }
        // SaveManager.SavePlayer(pd);
    }

    public void modeOn(int i) {
        pd.setMode(i, toggles[i].isOn);
        
        if(i == 0 && toggles[i].isOn) {
            toggles[1].interactable = false;
        } else if(i == 1 && toggles[i].isOn) {
            toggles[0].interactable = false;
        } else if(!toggles[0].isOn && !toggles[1].isOn) {
            toggles[0].interactable = true;
            toggles[1].interactable = true;
        }
        SaveManager.SavePlayer(pd);
        // Debug.Log(pd.getModes()[0] + " " + pd.getModes()[1] + " " + pd.getModes()[2]);
    }
}
