using UnityEngine;

public class FlightController : MonoBehaviour
{
    public FlightControls controls;

    public float minimumSpeed = 35.0f;
    public float maximumSpeed = 120.0f;
    public float speed = 90.0f;
    public float acceleration = 10f;
    public float deceleration = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(controls.moreSpeed) > 0) {
            speed += acceleration * Time.deltaTime;
        }
        else {
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, minimumSpeed, maximumSpeed);


        transform.Rotate(Input.GetAxis(controls.verticalAxis), 0.0f, -Input.GetAxis(controls.horizontalAxis));
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
