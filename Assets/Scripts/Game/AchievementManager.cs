using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : AchievementsSuper
{
    private GameObject achPanel;
    private GameObject achTitle;
    public static bool[] triggers = new bool[numAchs];
    public static int ach01Count;
    private static int ach01TriggerInt = 1000;
    private bool[] got = new bool[numAchs];

    private void Awake() {
        ach01Count = 0;
    }

    private void Update() {
        triggers[1] = (ach01Count >= ach01TriggerInt);
        for(int i = 1; i < codes.Length; i++) {
            got[i] = SaveManager.currentPlayer.getCodes()[i];
            if (triggers[i] && !got[i]) {
                StartCoroutine( TriggerAch(i) );
            }
        }
    }

    private IEnumerator TriggerAch(int i) {
        got[i] = true;
        triggers[i] = false;
        SaveManager.currentPlayer.setCode(i);
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
