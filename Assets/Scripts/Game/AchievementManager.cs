using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public GameObject achPanel;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;
    public GameObject achImage;

    public static int ach01Count;
    public int ach01Trigger = 1000;
    public int ach01Code;

    public Texture[] textures;

    public static bool ach02Trigger = false;
    public int ach02Code;

    public void Awake() {
        
    }

    // Update is called once per frame
    public void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        ach02Code = PlayerPrefs.GetInt("Ach02");
        if ((ach01Count >= ach01Trigger) && (ach01Code != 12345)) {
            StartCoroutine( Trigger01Ach() );
        }
        if (ach02Trigger && (ach02Code != 123456)) {
            StartCoroutine( Trigger02Ach() );
        }
    }

    IEnumerator Trigger01Ach() {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        achImage.GetComponent<RawImage>().texture = textures[0];
        achTitle.GetComponent<Text>().text = "High Scorer";
        achDesc.GetComponent<Text>().text = "Score 1000 points";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        achPanel.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achTitle.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger02Ach() {
        achActive = true;
        ach02Code = 123456;
        PlayerPrefs.SetInt("Ach02", ach02Code);
        achImage.GetComponent<RawImage>().texture = textures[1];
        achTitle.GetComponent<Text>().text = "Watch where you're going";
        achDesc.GetComponent<Text>().text = "Die to the same asteroid twice";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        achPanel.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achTitle.GetComponent<Text>().text = "";
        achActive = false;
    }
}
