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
    public double aircraft1Score = 0; // number of checkPoints collected by aircraft1
    public double aircraft2Score = 0; // number of checkPoints collected by aircraft2
    public double numberOfCheckPoints = 5; // number of all checkPoints in the game

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

    // add or remove points to or from a plane
    public void checkPointReached(double numberOfAircraft, double point)
    {
        if (numberOfAircraft == 1)
        {
            aircraft1Score += point;

            if (aircraft1Score == numberOfCheckPoints)
            {
                // player 1 wins
                Debug.Log("aircraft1 WON");
            }
        } else
        {
            aircraft2Score += point;

            if (aircraft2Score == numberOfCheckPoints)
            {
                // player 2 wins
                Debug.Log("aircraft2 WON");
            }
        }
        Debug.Log("aircraft1Score = " + aircraft1Score);
        Debug.Log("aircraft2Score = " + aircraft2Score);
    }
}
