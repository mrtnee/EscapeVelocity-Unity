using UnityEngine;

public class FlightController : MonoBehaviour
{
    public FlightControls controls;

    public float minimumSpeed = 35.0f;
    public float maximumSpeed = 120.0f;
    public float speed = 90.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        speed -= transform.forward.y * Time.deltaTime * 50.0f;

        speed = Mathf.Clamp(speed, minimumSpeed, maximumSpeed);
        
        transform.Rotate(Input.GetAxis(controls.verticalAxis), 0.0f, -Input.GetAxis(controls.horizontalAxis));


        float terrainHeightWherePlaneIs = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWherePlaneIs > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
                terrainHeightWherePlaneIs,
                transform.position.z);
            speed = 35.0f;
        }
    }
}
