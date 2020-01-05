using UnityEngine;

public class PewPewController : MonoBehaviour {

    public FlightControls controls;
    public LineRenderer laser;

    void Update() {
        if (Input.GetButton(controls.pewpew)) {
            Shoot();
        } else {
            laser.enabled = false;
        }
    }

    void Shoot() {
        laser.enabled = true;
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        laser.SetPosition(0, ray.origin);
        laser.SetPosition(1, ray.GetPoint(1000));

        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 100000)) {
            // Check if the element that we have shot has a script target
            Target target = hit.transform.GetComponent<Target>();
            if (target != null) {
                // The element has a Target script, therefore it is a aircraft
                StartCoroutine(target.Die());
            }
        }
    }

}