using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ParticleSystem explosion;
    public Text scoreText;
    public Text livesText;
    public EndMenu gameOver;

    public int lives;
    public float respawnTime = 3.0f;
    public float invulnTime = 2.0f;
    public int score;
    public int scoreMult;
    public int total;
    public static bool paused;
    public static bool isGameOver;

    public void Awake() {
        Time.timeScale = 1f;
        isGameOver = false;
        paused = false;
        score = 0;
        scoreMult = 25;
        total = 0;
        lives = 3;
    }

    public void Update() {
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

        if (asteroid.size < 2.5f) {
            score = (4 * scoreMult);
        } else if (asteroid.size < 4.0f) {
            score = (2 * scoreMult);
        } else {
            score = (1 * scoreMult);
        }
        total += score;
        scoreText.text = "Score : " + total.ToString();
        AchievementManager.ach01Count += score;
    }

    public void PlayerDied() {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        livesChange(false);

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
        isGameOver = true;
        livesText.enabled = false;
        scoreText.enabled = false;
        gameOver.Show(score);
    }

    public void livesChange(bool change) {
        if (change) {
            this.lives++;
        } else {
            this.lives--;
        }
        livesText.text = "Lives  : " + lives.ToString();
    }
}
