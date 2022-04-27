using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject optionsMenu;

    private void showControls() {
        controlsPanel.SetActive(true);
        optionsMenu.SetActive(false);
    }

    private void hideControls() {
        optionsMenu.SetActive(true);
        controlsPanel.SetActive(false);
    }
}
