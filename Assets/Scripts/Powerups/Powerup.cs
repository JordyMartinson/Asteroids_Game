using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Powerup : MonoBehaviour
{
    protected AudioSource audioSource;
    public AudioClip clip;
    protected SpriteRenderer sr;
    protected GameObject pTextDisplay;
    protected Color textCol;
    protected CircleCollider2D cCollider;
    protected GameManager gameManager;
    protected static float stayDuration = 7f;
    protected static float effectDuration = 5f;
    protected static float fadeStart = stayDuration * 0.8f;
    protected float alphaVal = 0f;
    protected float volume = 1f;
    protected bool powerupActive = false;
    protected string pText;

    protected void Start() {
        gameManager = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        cCollider = GetComponent<CircleCollider2D>();
        pTextDisplay = GameObject.Find("/UI/Header/PlayerStats/PowerupText");
        StartCoroutine(Fade(alphaVal, fadeStart));
    }

    protected void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine( Pickup(collision) );
        }
    }

    protected abstract IEnumerator Pickup (Collider2D player);

    protected void changeText(string text, Color colour) {
        pTextDisplay.GetComponent<Text>().text = text;
        pTextDisplay.GetComponent<Text>().color = colour;
        pTextDisplay.GetComponent<Text>().enabled = true;
    }

    protected IEnumerator Fade(float alphaVal, float fadeStart) {
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
