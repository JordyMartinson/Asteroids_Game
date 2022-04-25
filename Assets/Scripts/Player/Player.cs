using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    public string playerName;
    public int curScore;
    public float curTime; 
    public int highScore;
    public int timePlayed;
    public int bulletsFired;

    public Rigidbody2D rigidBody;
    public Bullet bulletPrefab;

    public float moveForce = 1.5f;
    public float turnForce = 0.25f;
    public int numBullets = 1;
    public int angleChange = -45;

    private bool forward;
    private float turn;

    private Camera mainCam;
    private Vector2 screenBounds;
    private PlayerData playerData;
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private bool[] playerModes;



    private void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        bulletsFired = 0;
        curScore = 0;
        curTime = 0;
        
        // mainCam = gameObject.GetComponent<Camera>();
        mainCam = Camera.main;

        playerData = SaveManager.currentPlayer; //change to current player
        playerModes = playerData.getModes();
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[playerData.getSpriteNum()];
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void Update() {
        if(playerModes[2]) {
            forward = true;
        } else {
            forward = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow);
        }

        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) {
            turn = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) {
            turn = -1.0f;
        } else {
            turn = 0.0f;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetMouseButtonDown(0) &
                !GameManager.paused & !playerModes[0]) {
            ShootBullets();
        }
    }

    private void LateUpdate() {
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));

        if(Mathf.Abs(transform.position.x) > screenBounds.x) {
            float xPos = Mathf.Clamp(transform.position.x, screenBounds.x, -(screenBounds.x));
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        if(Mathf.Abs(transform.position.y) > screenBounds.y) {
            float yPos = Mathf.Clamp(transform.position.y, screenBounds.y, -(screenBounds.y));
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        
    }

    private void FixedUpdate() {
        if (forward) {
            rigidBody.AddForce(this.transform.up * this.moveForce);
        }

        if (turn != 0.0f) {
            rigidBody.AddTorque(turn * this.turnForce);
        }
    }

    private void ShootBullets() {
        Vector3 fireAngle;
        Quaternion rotation;
        if(playerModes[1]) {
            fireAngle = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            rotation = Random.rotation;
            rotation *= Quaternion.Euler(0, 0, 0);
        } else {
            fireAngle = this.transform.up;
            rotation = this.transform.rotation;
            rotation *= Quaternion.Euler(0, 0, 0);
        }

        for (int i = 0; i < numBullets; i++) {
            Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, rotation);
            bullet.Shoot(fireAngle);
            rotation *= Quaternion.Euler(0, 0, angleChange);
            fireAngle = Quaternion.Euler(0, 0, angleChange) * fireAngle;
        }
        bulletsFired += numBullets;
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Asteroid") {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
