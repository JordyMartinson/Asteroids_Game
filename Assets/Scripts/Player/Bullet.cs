using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Camera mainCam;
    private Vector2 screenBounds;
    public float speed = 100.0f;
    public float maxLifetime = 10.0f;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
    }

    public void Shoot(Vector2 direction) {
        rb2D.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLifetime);
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        Destroy(this.gameObject);
    }

    private void LateUpdate() {
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));

        if(Mathf.Abs(transform.position.x) > screenBounds.x || Mathf.Abs(transform.position.y) > screenBounds.y){
            Destroy(this.gameObject);
        }        
    }
}
