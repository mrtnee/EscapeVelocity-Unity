using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeController : MonoBehaviour
{
    public Target opponent;
    public FlightControls controls;
    public float minDistance = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(controls.kamikaze) > 0) {
            // First destroy our spaceship
            foreach (Target t in GetComponentsInChildren<Target>()) {
                StartCoroutine(t.Die());
            }

            // If the distance between the aircrafts is small enough, destroy the opponent's aircraft
            // as well
            if (Vector3.Distance(transform.position, opponent.transform.position) <= minDistance) {
                StartCoroutine(opponent.Die());
            }
        }
    }
}
