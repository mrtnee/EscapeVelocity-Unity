using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField]
    float flightSpeed = 30;
    [SerializeField]
    float rollSpeed = 30;
    [SerializeField]
    float pitchSpeed = 30;

    bool up;
    bool down;
    bool right;
    bool left;
    bool accelerate;
    bool shoot;

    float dt;

    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        dt = Time.deltaTime;



        transform.Rotate(Input.GetAxis("Vertical") * dt * pitchSpeed, 0.0f, -Input.GetAxis("Horizontal") * dt * rollSpeed);
        transform.position += transform.forward * dt * flightSpeed;
    }

    // Update is called once per pyhisics update
    private void FixedUpdate()
    {
        
    }
}
