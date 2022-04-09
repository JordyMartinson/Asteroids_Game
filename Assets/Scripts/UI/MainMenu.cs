using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Awake() {
        // PlayerPrefs.DeleteAll();
        // Player player1 = new Player();
        // player1.playerName = "John";
        // player1.highScore = 40;
        // player1.timePlayed = 3;
        // SaveManager.SavePlayer(player1);

        // Player player2 = new Player();
        // player2.playerName = "Jane";
        // player2.highScore = 5000;
        // player2.timePlayed = 405;
        // SaveManager.SavePlayer(player2);
    }

    public void Quit() {

        // for(int i = 1; i < codes.Length; i++) {
        //     got[i] = PlayerPrefs.GetInt(codes[i]) == 1? true : false;
        //     if (triggers[i] && !got[i]) {
        //         StartCoroutine( TriggerAch(i) );
        //     }
        // }

        PlayerPrefs.DeleteAll();
        // Application.Quit();
    }
}
