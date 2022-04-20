using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : AchievementsSuper
{
    public GameObject achPanel;
    public bool achActive = false;
    public GameObject achTitle;


    public static bool[] triggers = new bool[numAchs];
    public static int ach01Count;
    public int ach01TriggerInt = 1000;
    public bool[] got = new bool[numAchs];

    public void Awake() {
        ach01Count = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        triggers[1] = (ach01Count >= ach01TriggerInt);

        for(int i = 1; i < codes.Length; i++) {
            got[i] = PlayerPrefs.GetInt(codes[i]) == 1? true : false;
            if (triggers[i] && !got[i]) {
                StartCoroutine( TriggerAch(i) );
            }
        }
    }

    IEnumerator TriggerAch(int i) {
        achActive = true;
        got[i] = true;
        triggers[i] = false;
        PlayerPrefs.SetInt(codes[i], got[i] ? 1:0);

        AchPanel newPanel = Instantiate(achPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Header").transform);
        newPanel.title.GetComponent<Text>().text = titles[i];
        newPanel.image.GetComponent<RawImage>().texture = textures[i];
        newPanel.rt.anchorMin = Vector2.one;
        newPanel.rt.anchorMax = Vector2.one;
        newPanel.rt.pivot = Vector2.one;
        newPanel.rt.anchoredPosition = Vector3.zero;
        yield return new WaitForSeconds(5f);
        Reset();
    }
}
