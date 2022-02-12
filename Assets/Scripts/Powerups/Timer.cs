using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timerBar;
    public float maxTime;
    public float timeLeft;

    // Start is called before the first frame update
    public void Start()
    {
        timerBar = GetComponent<Image>();
        timerBar.enabled = false;
        maxTime = Powerup.effectDuration;
        timeLeft = maxTime;
    }

    // Update is called once per frame
    public void TickDown()
    {
        timerBar.enabled = true;
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        } else {
            timerBar.enabled = false;
        }
    }
}
