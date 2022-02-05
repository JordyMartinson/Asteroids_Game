using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text scoreText;
    public Text headerText;
    public Text subText;

    public void Show(int score) {
        gameObject.SetActive(true);
        headerText.text = "GAME OVER";
        subText.text = "FINAL SCORE";
        scoreText.text = score.ToString();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
