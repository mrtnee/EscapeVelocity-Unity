using UnityEngine;

public class PewPewController : MonoBehaviour {

    public FlightControls controls;

    void Update() {
        if (Input.GetKey(controls.pewpew)) {
            Shoot();
        }
    }

    void Shoot() {
        Debug.Log("SHOOT");
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 100000)) {
            // We have hit something, check if the object that was shot is in group aircraft
            if (hit.transform.tag.Equals("aircraft")) {
                Debug.Log(hit.transform.name);
            }
        }
    }

}