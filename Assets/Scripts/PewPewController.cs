using UnityEngine;

public class PewPewController : MonoBehaviour {

    public FlightControls controls;

    void Update() {
        if (Input.GetButton(controls.pewpew)) {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 100000)) {
            // Check if the element that we have shot has a script target
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                // The element has a Target script, therefore it is a aircraft
                target.Die();
            }
        }
    }

}