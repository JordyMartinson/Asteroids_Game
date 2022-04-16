using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public static float stayDuration = 7f;
    public float fadeStart = stayDuration * 0.8f;
    public static float effectDuration = 5f;
    public float alphaVal = 0f;
    public bool powerupActive = false;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;

    SpriteRenderer sr;

    public void Start() {
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Fade(alphaVal, fadeStart));
    }

    IEnumerator Fade(float alphaVal, float fadeStart) {
        yield return new WaitForSeconds(fadeStart);
        float alpha = sr.color.a;

        for (float t = 0f; t < 1f; t += Time.deltaTime / (stayDuration - fadeStart)) {
            Color newAlpha = new Color(sr.color.r, sr.color.g, sr.color.b, Mathf.Lerp(alpha, alphaVal, t));
            sr.color = newAlpha;
            yield return null;
        }
        if (!powerupActive) {
            Destroy(this.gameObject);
        }
    }
}
