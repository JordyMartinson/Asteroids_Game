using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float speed = 100.0f;
    public float maxLifetime = 10.0f;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction) {
        rb2D.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        Destroy(this.gameObject);
    }
}
