using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip death;
    [SerializeField] private AudioClip hit;
    [SerializeField] private Player player;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private GameObject header;
    [SerializeField] private EndMenu gameOver;
    public static bool paused;
    private static bool isGameOver;
    private int score;
    private int scoreMult;
    private int lives;
    private float startTime;
    private bool[] playerModes;
    private float respawnTime = 3.0f;
    private float invulnTime = 2.0f;
    private float volume = 1f;
    private float minute = 60f;
    private float fiveSecs = 5f;

    private void Awake() {
        playerData = SaveManager.currentPlayer;
        playerData.reset();
        playerModes = playerData.getModes();
        Time.timeScale = 1f;
        isGameOver = false;
        paused = false;
        score = 0;
        scoreMult = 25;
        for(int i = 0; i < playerModes.Length; i++) {
            if(playerModes[i]) {
                scoreMult += 25;
            }
        }
        lives = 3;
        startTime = Time.time;
        audioSource = GetComponent<AudioSource>();
        header = GameObject.Find("/UI/Header");
        header.SetActive(true);
        if(playerModes[0]) {
            InvokeRepeating(nameof(pacifistScorer), fiveSecs, fiveSecs);
        }
    }

    private void pacifistScorer() {
        playerData.curScore += scoreMult;
        scoreUpdate();
    }

    private void Update() {
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

    private void PauseUnpause(float time) {
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
        if (asteroid.getSize() < 2.5f) {
            score = (4 * scoreMult);
        } else if (asteroid.getSize() < 4.0f) {
            score = (2 * scoreMult);
        } else {
            score = (1 * scoreMult);
        }
        scoreUpdate();
    }

    private void scoreUpdate() {
        playerData.curScore += score;
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
        isGameOver = true;
        header.SetActive(false);
        gameOver.Show(playerData.curScore, playerData.curTime);
    }

    public void LivesChange(bool change) {
        if (change) {
            this.lives++;
        } else {
            this.lives--;
        }
        livesText.text = "Lives  : " + lives.ToString();
    }

    public PlayerData getPlayerData() {
        playerData.setBulletsFired(player.getBulletsFired());
        return this.playerData;
    }

    public Player getPlayer() {
        return this.player;
    }

    public int getMult() {
        return this.scoreMult;
    }

    public void setMult(int setMult) {
        this.scoreMult = setMult;
    }
}
