using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLifePU : Powerup
{
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine( Pickup(collision) );
        }
    }

    IEnumerator Pickup (Collider2D player) {
        audioSource.PlayOneShot(clip, volume);
        changeText("EXTRA LIFE", Color.green);
        FindObjectOfType<GameManager>().LivesChange(true);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        powerupActive = true;
        yield return new WaitForSeconds(effectDuration);
        powerupActive = false;
        pTextDisplay.GetComponent<Text>().enabled = false;
        Destroy(gameObject);
    }
}
