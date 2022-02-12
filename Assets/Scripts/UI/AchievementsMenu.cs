using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : AchievementsSuper
{
    public int achOffset = -110;
    public Vector3 vector = new Vector3(0, -100, 0);

    public void SetAchieved() {
        for (int i = 1; i < (codes.Length); i++) {
            AchPanel newPanel = Instantiate(achPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("AchScrollContent").transform);
            newPanel.rt.anchorMin = new Vector2(0.5f, 1);
            newPanel.rt.anchorMax = new Vector2(0.5f, 1);
            newPanel.rt.pivot = new Vector2(0.5f, 0.5f);
            newPanel.rt.sizeDelta = new Vector2(600, 100);
            newPanel.title.GetComponent<Text>().text = titles[i];
            Vector3 newVector = new Vector3(350, (i * achOffset), 0);
            newPanel.rt.anchoredPosition = newVector;

            if ((PlayerPrefs.GetInt(codes[i]) == 1? true:false)) {
                newPanel.desc.GetComponent<Text>().text = descriptions[i];
                newPanel.image.GetComponent<RawImage>().texture = textures[i];
            } else {
                newPanel.desc.GetComponent<Text>().text = descriptions[0];
                newPanel.image.GetComponent<RawImage>().texture = textures[0];
            }
            Time.timeScale = 0f;
        }
    }
}
