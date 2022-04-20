using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject optionsMenu;

    public void showControls() {
        controlsPanel.SetActive(true);
        optionsMenu.SetActive(false);
        // optionsMenu.transform.localScale = Vector3.zero;
    }

    public void hideControls() {
        // optionsMenu.transform.localScale = Vector3.one;
        optionsMenu.SetActive(true);
        controlsPanel.SetActive(false);
    }
}
