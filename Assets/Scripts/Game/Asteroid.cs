using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private PolygonCollider2D pc2D;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Powerup[] powerups;
    private float size = 4.0f;
    private float minSize = 2.0f;
    private float maxSize = 6.0f;
    private float speed = 15.0f;
    private float maxLifetime = 30.0f;
    private float powerupChance = 10f;
    private bool playerKill = false;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        pc2D = GetComponent<PolygonCollider2D>();
    }

    private void Start() {
        sr.sprite = sprites[Random.Range(0, sprites.Length-1)];
        UpdatePolygonCollider2D();
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
            float randChance = Random.Range(0f, 100f);
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
        half.size = this.size/2;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }

    private void UpdatePolygonCollider2D() {
        List<Vector2> points = new List<Vector2>();
        List<Vector2> simplePoints = new List<Vector2>();
        pc2D.pathCount = sr.sprite.GetPhysicsShapeCount();
        for(int i = 0; i < pc2D.pathCount; i++) {
            sr.sprite.GetPhysicsShape(i, points);
            LineUtility.Simplify(points, 0.05f, simplePoints);
            pc2D.SetPath(i, simplePoints);
        }
    }

    public float getSize() {
        return this.size;
    }

    public float getMinSize() {
        return this.minSize;
    }

    public float getMaxSize() {
        return this.maxSize;
    }

    public void setSize(float setSize) {
        this.size = setSize;
    }
}
