using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : MonoBehaviour
{
    public Texture[] textures;
    public GameObject achDesc;
    public GameObject ach01Image;

    public string descPH = "?";
    
    public void Awake() {
    }

    public void FixedUpdate() {
        SetAchieved();
    }

    public void SetAchieved() {
        if (PlayerPrefs.GetInt("Ach01") == 12345) {
            achDesc.GetComponent<Text>().text = "Score 1000 points";
            ach01Image.GetComponent<RawImage>().texture = textures[1];
        } else {
            ResetAchievement();
        }
    }

    public void ResetAchievement() {
        achDesc.GetComponent<Text>().text = descPH;
        ach01Image.GetComponent<RawImage>().texture = textures[0];
    }
}
