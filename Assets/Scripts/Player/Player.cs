using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerShoot shooting;
    [SerializeField] private Sprite[] sprites;
    public string playerName;
    public int curScore;
    public int highScore;
    public int timePlayed;
    public int bulletsFired;
    public float curTime;
    public float turn;
    public bool forward;
    public bool[] playerModes;
    public int numBullets = 1;
    public int angleChange = -45;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
        rigidBody = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        shooting = GetComponent<PlayerShoot>();
        bulletsFired = 0;
        curScore = 0;
        curTime = 0;
        playerData = SaveManager.currentPlayer;
        playerModes = playerData.getModes();
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[playerData.getSpriteNum()];
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void Update() {
        movement.update(this);
        shooting.update(this);
    }

    private void LateUpdate() {
        movement.lateUpdate(this);
    }

    private void FixedUpdate() {
        movement.fixedUpdate(this);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Asteroid") {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            gameManager.PlayerDied();
        }
    }

    public PlayerData getPlayerData() {
        return this.playerData;
    }

    public Rigidbody2D getRigidBody() {
        return this.rigidBody;
    }

    public void setName(string setName) {
        this.playerName = setName;
    }

    public int getBulletsFired() {
        return this.bulletsFired;
    }

    public int getNumBullets() {
        return this.numBullets;
    }

    public void setNumBullets(int setNum) {
        this.numBullets = setNum;
    }

    public void setBulletsFired(int setBullets) {
        this.bulletsFired = setBullets;
        playerData.setBulletsFired(bulletsFired);
    }
}
