using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text headerText;
    [SerializeField] private Text subText;
    private GameManager gameManager;
    private int endScore = 0;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Show(int total) {
        gameObject.SetActive(true);
        headerText.text = "GAME OVER";
        subText.text = "FINAL SCORE";
        scoreText.text = total.ToString();
        endScore = total;
    }

    public void Pause() {
        if (gameObject.activeSelf) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
            headerText.text = "PAUSE";
            subText.text = "";
            scoreText.text = "";
        }
    }

    private void Restart() {
        PlayerData pD = SaveManager.currentPlayer;
        SaveManager.UpdateSave(pD);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitGame() {
        PlayerData pD = SaveManager.currentPlayer;
        SaveManager.UpdateSave(pD);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
