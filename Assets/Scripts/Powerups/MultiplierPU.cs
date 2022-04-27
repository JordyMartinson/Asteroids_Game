using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierPU : Powerup
{
    protected override IEnumerator Pickup (Collider2D player) {
        audioSource.PlayOneShot(clip, volume);
        changeText("2X SCORE", Color.red);
        gameManager.setMult(gameManager.getMult()*2);
        sr.enabled = false;
        cCollider.enabled = false;
        powerupActive = true;
        yield return new WaitForSeconds(effectDuration);
        powerupActive = false;
        gameManager.setMult(gameManager.getMult()/2);
        pTextDisplay.GetComponent<Text>().enabled = false;
        Destroy(gameObject);
    }
}
