using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public GameManager gameManager;

    public Text scoreText;
    public Text headerText;
    public Text subText;
    public int endScore = 0;

    public void Awake() {
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

    public void Restart() {
        // PlayerPrefs.SetInt("timePlayed", (PlayerPrefs.GetInt("timePlayed") + (int)FindObjectOfType<GameManager>().t));
        // PlayerStatsManager.AddTimeToTotal();
        PlayerData pD = new PlayerData(gameManager.getPlayer());
        SaveManager.UpdateSave(pD);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        // PlayerPrefs.SetInt("timePlayed", (PlayerPrefs.GetInt("timePlayed") + (int)FindObjectOfType<GameManager>().t));
        // PlayerData pD = new PlayerData(gameManager.getPlayerData());
        PlayerData pD = gameManager.getPlayerData();
        pD.curScore = endScore;
        // Debug.Log("pd " + pD.getSpriteNum());
        SaveManager.UpdateSave(gameManager.getPlayerData());
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        
    }
}
