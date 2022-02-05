using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Bullet bulletPrefab;

    public float moveForce = 1.5f;
    public float turnForce = 0.25f;
    public int numBullets = 1;
    public int angleChange = -45;

    private bool forward;
    private float turn;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        forward = Input.GetKey(KeyCode.W);
        if (Input.GetKey(KeyCode.A)) {
            turn = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D)) {
            turn = -1.0f;
        } else {
            turn = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) & !GameManager.paused) {
            ShootBullets();
        }
    }

    private void FixedUpdate() {
        if (forward) {
            rb2D.AddForce(this.transform.up * this.moveForce);
        }

        if (turn != 0.0f) {
            rb2D.AddTorque(turn * this.turnForce);
        }
    }

    private void ShootBullets() {
        var fireAngle = this.transform.up;
        var rotation = this.transform.rotation;
        rotation *= Quaternion.Euler(0, 0, 90);

        for (int i = 0; i < numBullets; i++) {
            Bullet bullet = Instantiate(this.bulletPrefab,
                this.transform.position, rotation);

            bullet.Shoot(fireAngle);
            rotation *= Quaternion.Euler(0, 0, angleChange);
            fireAngle = Quaternion.Euler(0, 0, angleChange) * fireAngle;
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Asteroid") {
            rb2D.velocity = Vector3.zero;
            rb2D.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
