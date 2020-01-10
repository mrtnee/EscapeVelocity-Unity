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

    public Camera introCamera;
    public GameObject introUiObjects;
    public GameObject outroUiObjects;
    public GameObject gameUiObjects;

    public double aircraft1Score = 0; // number of checkPoints collected by aircraft1
    public double aircraft2Score = 0; // number of checkPoints collected by aircraft2

    public GameObject aircraft1, aircraft2;

    public GameObject aircraft1Scoreboard;
    public GameObject aircraft2Scoreboard;
    public GameObject checkpointUiPrefab;

    public double numberOfCheckPoints = 5; // number of all checkPoints in the game

    private bool gameStarted = false;

    public List<ParticleSystem> spermEmiters = new List<ParticleSystem>();

    void Start() {
        // Hide all game UI elements
        gameUiObjects.SetActive(false);
        introUiObjects.SetActive(true);
        outroUiObjects.SetActive(false);

        // Disable aircraft moving
        SetAircraftsEnabled(false);
    }

    void SetAircraftsEnabled(bool isEnabled) {
        FlightController firstAircraftScript = aircraft1.GetComponent<FlightController>();
        FlightController secondAircraftScript = aircraft2.GetComponent<FlightController>();
        if (firstAircraftScript != null) firstAircraftScript.isDead = !isEnabled;
        if (secondAircraftScript != null) secondAircraftScript.isDead = !isEnabled;
    }

    void StartGame() {
        gameStarted = true;

        UpdateScoreboards();
        StartCoroutine("Countdown");

        SetAircraftsEnabled(true);

        // Display game UI elements and hide intro camera
        introCamera.enabled = false;
        gameUiObjects.SetActive(true);
        introUiObjects.SetActive(false);
        outroUiObjects.SetActive(false);
    }

    void EndGame() {
        StopCoroutine("Countdown");

        UpdateScoreboards();

        SetAircraftsEnabled(false);

        // Display outro UI elements and display intro camera
        introCamera.enabled = true;
        gameUiObjects.SetActive(false);
        introUiObjects.SetActive(false);
        outroUiObjects.SetActive(true);

        foreach (ParticleSystem element in spermEmiters) {
            element.Play();
        }
    }
    
    void Update() {
        if (!gameStarted) {
            if (Input.anyKey) {
                StartGame();
            }
            return;
        }

        UpdateCanvas();

        if (timer <= 0) {
            // Game Over
            EndGame();
            timer = 10000;
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
                EndGame();
            }
        } else
        {
            aircraft2Score += point;

            if (aircraft2Score == numberOfCheckPoints)
            {
                // player 2 wins
                Debug.Log("aircraft2 WON");
                EndGame();
            }
        }
        Debug.Log("aircraft1Score = " + aircraft1Score);
        Debug.Log("aircraft2Score = " + aircraft2Score);

        UpdateScoreboards();
    }

    private void UpdateScoreboards() {
        UpdateScoreboard(aircraft1Scoreboard, (int) aircraft1Score);
        UpdateScoreboard(aircraft2Scoreboard, (int) aircraft2Score);
    }

    private void UpdateScoreboard(GameObject scoreboard, int score) {
        // First, remove all children of scoreboard
        for (int i = 0; i < scoreboard.transform.childCount; i++) {
            GameObject.Destroy(scoreboard.transform.GetChild(i).gameObject);
        }

        // The center position of the aircraft scoreboard element
        Vector3 position = scoreboard.transform.position;

        double prefabSize = 11.3;
        double margin = 20;

        // Total height is (n * diagonal of prefab) + ((n - 1) * margin)
        double totalHeight = score * prefabSize + (score - 1) * margin;
        double firstPosition = -totalHeight / 2 + (prefabSize / 2);

        for (int i = 0; i < score; i++) {
            Vector3 delta = new Vector3(0, (float)(firstPosition + i * (prefabSize + margin)), 0);
            // Create a new instance of CheckpointUI prefab
            GameObject checkpoint = Instantiate(checkpointUiPrefab, position + delta, Quaternion.identity);
            // Set the aircraft scoreboard as its parent
            checkpoint.transform.parent = aircraft1Scoreboard.transform;
        }
    }
}
