using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public double timer = 120d;
    public Canvas canvas;
    public TextMeshProUGUI timerText;
    


    void Start() {
        StartCoroutine("Countdown");
    }
    
    void Update() {
        UpdateCanvas();

        if (timer <= 0) {
            // Game Over
            StopCoroutine("Countdown");
        }
    }

    void UpdateCanvas()
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timer);
        string time = timeSpan.ToString("mm\\:ss");
        timerText.text = time;
    }

    IEnumerator Countdown()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            timer -= 1;
        }
    }
}
