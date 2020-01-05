using UnityEngine;

public class PewPewController : MonoBehaviour {

    public KeyCode shoot;

    void Update() {
        if (Input.GetKey(shoot)) {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 100000)) {
            // We have hit something, check if the object that was shot is in group aircraft
            if (hit.transform.tag.Equals("aircraft")) {
                Debug.Log(hit.transform.name);
            }
        }
    }

}