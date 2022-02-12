using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePU : Powerup
{
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Pickup(collision);
        }
    }

    private void Pickup (Collider2D player) {
        FindObjectOfType<GameManager>().LivesChange(true);
        Destroy(gameObject);
    }
}
