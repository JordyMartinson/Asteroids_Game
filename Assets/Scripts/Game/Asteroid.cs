using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 4.0f;
    public float minSize = 2.0f;
    public float maxSize = 6.0f;
    public float speed = 15.0f;
    public float maxLifetime = 60.0f;
    
    public Powerup[] powerups;
    public float powerupChance = 10f;

    private SpriteRenderer sr;
    private Rigidbody2D rb2D;
    // public Powerup powerup;

    public bool playerKill = false;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
        sr.sprite = sprites[Random.Range(0, sprites.Length-1)];
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
        
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        this.transform.localScale = Vector3.one * this.size;

        rb2D.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction) {
        rb2D.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {

            var randChance = Random.Range(0f, 100f);
            if (randChance <= powerupChance) {
                Instantiate(powerups[Random.Range(0, powerups.Length)],
                    transform.position, Quaternion.identity);
            }

            if ((this.size / 2) >= this.minSize) {
                CreateSplit();
                CreateSplit();
            }
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player") {
            if (playerKill) {
                AchievementManager.triggers[2] = true;
            } else {
                playerKill = true;
            }
        }
    }

    private void CreateSplit() {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Asteroid half = Instantiate(this, position, this.transform.rotation);
        half.size = this.size / 2;

        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }
}
