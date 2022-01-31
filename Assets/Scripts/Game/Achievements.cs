using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{

    public GameObject achPanel;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    public GameObject ach01Image;
    public static int ach01Count;
    public int a = ach01Count;
    public int ach01Trigger = 1000;
    public int ach01Code;

    public void Start() {
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    public void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        if ((ach01Count == ach01Trigger) && (ach01Code != 12345)) {
            StartCoroutine( Trigger01Ach() );
        }
    }

    IEnumerator Trigger01Ach() {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement 1";
        achDesc.GetComponent<Text>().text = "Achievement text goes here";
        achPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        achPanel.SetActive(false);

        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achTitle.GetComponent<Text>().text = "";
        achActive = false;
    }
}
