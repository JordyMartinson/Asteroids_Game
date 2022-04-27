using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveForce = 1.5f;
    private float turnForce = 0.25f;
    private Camera mainCam;
    private Vector2 screenBounds;

    private void Awake() {
        mainCam = Camera.main;
    }

    public void update(Player player) {
        if(player.playerModes[2]) {
            player.forward = true;
        } else {
            player.forward = Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow);
        }

        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) {
            player.turn = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) {
            player.turn = -1.0f;
        } else {
            player.turn = 0.0f;
        }
    }

    public void fixedUpdate(Player player) {
        if (player.forward) {
            player.getRigidBody().AddForce(this.transform.up * this.moveForce);
        }

        if (player.turn != 0.0f) {
            player.getRigidBody().AddTorque(player.turn * this.turnForce);
        }
    }

    public void lateUpdate(Player player) {
        screenBounds = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCam.transform.position.z));

        if(Mathf.Abs(transform.position.x) > screenBounds.x) {
            float xPos = Mathf.Clamp(transform.position.x, screenBounds.x, -(screenBounds.x));
            player.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

        if(Mathf.Abs(transform.position.y) > screenBounds.y) {
            float yPos = Mathf.Clamp(transform.position.y, screenBounds.y, -(screenBounds.y));
            player.transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
    }
}
