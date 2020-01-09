using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCamera : MonoBehaviour
{
    void Update() {
        // Move camera slowly forward
        transform.Translate(Vector3.forward * 0.1f);
    }
}
