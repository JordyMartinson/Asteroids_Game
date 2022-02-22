using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    public void Awake() {
        Camera camera = gameObject.GetComponent<Camera>();
    }

    public void Reset() {
        // camera.position = new Vector3(0, 0, -10);
    }
}
