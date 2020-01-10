using UnityEngine;

public class FlightController : MonoBehaviour
{
    public FlightControls controls;

    public float minimumSpeed = 35.0f;
    public float maximumSpeed = 120.0f;
    public float speed = 90.0f;
    public float acceleration = 10f;
    public float deceleration = 10f;
    public float xRotSpeed = 100f;
    public float zRotSpeed = 100f;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetAxis(controls.moreSpeed) > 0) {
            speed += acceleration * Time.deltaTime;
        }
        else {
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, minimumSpeed, maximumSpeed);

        float xRotation = Input.GetAxis(controls.verticalAxis) * Time.deltaTime * xRotSpeed;
        float zRotation = Input.GetAxis(controls.horizontalAxis) * Time.deltaTime * zRotSpeed;
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.Rotate(xRotation, 0.0f, -zRotation);

        // Get terrain height at current aircraft position
        float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);

        // If the aircraft is below the world, destroy it
        if (terrainHeight > transform.position.y) {
            
            Target target = gameObject.GetComponentInChildren<Target>();
            if (target != null)
                StartCoroutine(target.Die());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("WorldBorder")) {
            Debug.Log("Return to the world!");
        }
    }
}
