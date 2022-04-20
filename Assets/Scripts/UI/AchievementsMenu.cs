using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsMenu : AchievementsSuper
{
    public int achOffset = -100;
    // public Vector3 vector = new Vector3(0, -100, 0);

    IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        SetAchieved();
    }

    public void SetAchieved() {
        for (int i = 1; i < (codes.Length); i++) {
            AchPanel newPanel = Instantiate(achPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("AchMainPanel").transform);
            newPanel.rt.anchorMin = new Vector2(0.5f, 1);
            newPanel.rt.anchorMax = new Vector2(0.5f, 1);
            newPanel.rt.pivot = new Vector2(0.5f, 0.5f);
            newPanel.rt.sizeDelta = new Vector2(700, 100);
            newPanel.title.GetComponent<Text>().text = titles[i];
            Vector3 newVector = new Vector3(0, (i * achOffset), 0);
            newPanel.rt.anchoredPosition = newVector;

            if (SaveManager.currentPlayer.getCodes()[i]) {
                newPanel.desc.GetComponent<Text>().text = descriptions[i];
                newPanel.image.GetComponent<RawImage>().texture = textures[i];
            } else {
                newPanel.desc.GetComponent<Text>().text = descriptions[0];
                newPanel.image.GetComponent<RawImage>().texture = textures[0];
            }
        }
    }
}
