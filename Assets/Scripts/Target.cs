using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject aircraft;
    public ParticleSystem explosion;

    public float waitAfterDeath = 0.5f;
    private bool isCurrentlyDying = false;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private void Awake() {
        spawnPosition = aircraft.transform.position;
        spawnRotation = aircraft.transform.rotation;
    }

    public IEnumerator Die() {
        // This target was already hit, don't play the explosion
        if (isCurrentlyDying)
            yield break;

        FlightController controller = aircraft.GetComponent<FlightController>();

        isCurrentlyDying = true;
        controller.isDead = true;

        // Hide the player model
        gameObject.SetActive(false);

        // Play the explosion particle system
        explosion.Play();

        // After explosion has finished, move the player to a new random position
        yield return new WaitForSecondsRealtime(waitAfterDeath);

        MoveToSpawnPoint();

        // Display the player model
        gameObject.SetActive(true);

        isCurrentlyDying = false;
        controller.isDead = false;
    }

    private void MoveToSpawnPoint() {
        aircraft.transform.position = spawnPosition;
        spawnRotation = aircraft.transform.rotation;
    }

}