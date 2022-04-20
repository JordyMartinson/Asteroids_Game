using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public PlayerData playerData;
    public ParticleSystem explosion;
    public Text scoreText;
    public Text livesText;
    public GameObject header;
    public EndMenu gameOver;

    public int lives;
    public float respawnTime = 3.0f;
    public float invulnTime = 2.0f;
    public int score;
    public int scoreMult;
    public static bool paused;
    public static bool isGameOver;
    
    public float startTime;
    public static bool firedShot;

    private AudioSource audioSource;
    public AudioClip death;
    public AudioClip hit;
    public float volume = 1f;
    public float minute = 60f;

    public void Awake() {
        Time.timeScale = 1f;
        isGameOver = false;
        paused = false;
        score = 0;
        scoreMult = 25;
        lives = 3;
        startTime = Time.time;
        firedShot = false;
        playerData = SaveManager.currentPlayer;
        playerData.reset();
        audioSource = GetComponent<AudioSource>();
        header = GameObject.Find("/UI/Header");
        header.SetActive(true);
    }

    public void Update() {
        playerData.curTime = Time.time - startTime;
        if (playerData.curTime >= minute) {
            AchievementManager.triggers[3] = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver) {
            if (paused) {
                PauseUnpause(1f);
            } else {
                PauseUnpause(0f);
            }
        }
    }

    public void PauseUnpause(float time) {
        gameOver.Pause();
        Time.timeScale = time;
        if (time == 0f) {
            paused = true;
        } else {
            paused = false;
        }
    }

    public void AsteroidDestroyed(Asteroid asteroid) {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();
        audioSource.PlayOneShot(hit, volume);

        if (asteroid.size < 2.5f) {
            score = (4 * scoreMult);
        } else if (asteroid.size < 4.0f) {
            score = (2 * scoreMult);
        } else {
            score = (1 * scoreMult);
        }
        playerData.curScore += score;
        // Debug.Log(playerData.curScore);
        scoreText.text = "Score : " + playerData.curScore.ToString();
        AchievementManager.ach01Count += score;
    }

    public void PlayerDied() {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        audioSource.PlayOneShot(death, volume);

        LivesChange(false);

        if (this.lives <= 0) {
            GameOver();
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn() {
        this.player.transform.position = Vector3.zero;
        this.player.transform.rotation = Quaternion.identity;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), invulnTime);
    }

    private void TurnOnCollisions() {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver() {

        // if(total > PlayerPrefs.GetInt("highScore")) {
        //     PlayerPrefs.SetInt("highScore", total);
        // }
        // PlayerPrefs.SetInt("timePlayed", (PlayerPrefs.GetInt("timePlayed") + (int)player.curTime));
        SaveManager.UpdateSave(this.playerData);
        isGameOver = true;
        // livesText.enabled = false;
        // scoreText.enabled = false;
        header.SetActive(false);
        gameOver.Show(playerData.curScore);
    }

    public void LivesChange(bool change) {
        if (change) {
            this.lives++;
        } else {
            this.lives--;
        }
        livesText.text = "Lives  : " + lives.ToString();
    }

    // public void UpdateSave() {
    //     PlayerData old = SaveManager.LoadPlayer();
    //     if(player.curScore > old.highScore) {
    //         player.highScore = player.curScore; //check
    //     }
    //     player.timePlayed = old.timePlayed + (int)player.curTime;
    //     player.bulletsFired += old.bulletsFired;
    //     SaveManager.SavePlayer(this.player);
    // }

    public PlayerData getPlayerData() {
        playerData.bulletsFired = player.bulletsFired;
        // playerData.setSpriteNum(3);
        // Debug.Log(playerData.getSpriteNum());
        return this.playerData;
    }

    public Player getPlayer() {
        // Debug.Log(player.playerName);
        return this.player;
    }
}
