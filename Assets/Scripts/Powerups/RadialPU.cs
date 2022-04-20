using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialPU : Powerup
{
    public int radial = 8;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine( Pickup(collision) );
        }
    }

    IEnumerator Pickup (Collider2D player) {
        audioSource.PlayOneShot(clip, volume);
        // pText = "EXTRA BULLETS";
        changeText("EXTRA BULLETS", Color.white);
        Player playerScript = player.GetComponent<Player>();
        playerScript.numBullets = radial;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        powerupActive = true;
        yield return new WaitForSeconds(effectDuration);
        powerupActive = false;
        playerScript.numBullets = radial/radial;
        pTextDisplay.GetComponent<Text>().enabled = false;
        Destroy(gameObject);
    }
}
