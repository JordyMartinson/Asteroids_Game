using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierPU : Powerup
{
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine( Pickup(collision) );
        }
    }

    IEnumerator Pickup (Collider2D player) {
        FindObjectOfType<GameManager>().scoreMult *= 2;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(effectDuration);

        FindObjectOfType<GameManager>().scoreMult /= 2;

        Destroy(gameObject);
    }
}
