using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject title;
    public GameObject desc;
    public GameObject image;
    public RectTransform rt;

    private void Awake() {
        rt = GetComponent<RectTransform>();
    }
}
