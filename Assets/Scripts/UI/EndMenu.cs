using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text scoreText;
    public Text headerText;
    public Text subText;

    public void Show(int total) {
        gameObject.SetActive(true);
        headerText.text = "GAME OVER";
        subText.text = "FINAL SCORE";
        scoreText.text = total.ToString();
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
        PlayerPrefs.SetInt("timePlayed", (PlayerPrefs.GetInt("timePlayed") + (int)FindObjectOfType<GameManager>().t));
        // PlayerStatsManager.AddTimeToTotal();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        PlayerPrefs.SetInt("timePlayed", (PlayerPrefs.GetInt("timePlayed") + (int)FindObjectOfType<GameManager>().t));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
