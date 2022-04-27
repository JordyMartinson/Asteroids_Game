using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RadialPU : Powerup
{
    private int radial = 8;

    protected override IEnumerator Pickup (Collider2D player) {
        audioSource.PlayOneShot(clip, volume);
        changeText("EXTRA BULLETS", Color.white);
        Player playerScript = player.GetComponent<Player>();
        playerScript.setNumBullets(radial);
        sr.enabled = false;
        cCollider.enabled = false;
        powerupActive = true;
        yield return new WaitForSeconds(effectDuration);
        powerupActive = false;
        playerScript.setNumBullets(radial/radial);
        pTextDisplay.GetComponent<Text>().enabled = false;
        Destroy(gameObject);
    }
}
