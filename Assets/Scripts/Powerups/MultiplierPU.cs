using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierPU : Powerup
{
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine( Pickup(collision) );
        }
    }

    IEnumerator Pickup (Collider2D player) {
        audioSource.PlayOneShot(clip, volume);
        changeText("2X SCORE", Color.red);
        FindObjectOfType<GameManager>().scoreMult *= 2;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        powerupActive = true;
        yield return new WaitForSeconds(effectDuration);
        powerupActive = false;
        FindObjectOfType<GameManager>().scoreMult /= 2;
        pTextDisplay.GetComponent<Text>().enabled = false;
        Destroy(gameObject);
    }
}
