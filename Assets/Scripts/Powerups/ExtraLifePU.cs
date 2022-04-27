using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLifePU : Powerup
{
    protected override IEnumerator Pickup (Collider2D player) {
        audioSource.PlayOneShot(clip, volume);
        changeText("EXTRA LIFE", Color.green);
        gameManager.LivesChange(true);
        sr.enabled = false;
        cCollider.enabled = false;
        powerupActive = true;
        yield return new WaitForSeconds(effectDuration);
        powerupActive = false;
        pTextDisplay.GetComponent<Text>().enabled = false;
        Destroy(gameObject);
    }
}
