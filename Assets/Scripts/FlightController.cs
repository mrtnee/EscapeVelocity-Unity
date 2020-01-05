using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightController : MonoBehaviour
{

    public float speed = 90.0f;

    public string vertical;
    public string horizontal;
    public string shoot;
    public string acceleration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        speed -= transform.forward.y * Time.deltaTime * 50.0f;

        if (speed < 35.0f)
        {
            speed = 35.0f;
        }

        if (speed > 120.0f)
        {
            speed = 120.0f;
        }


        
        transform.Rotate(Input.GetAxis(vertical), 0.0f, -Input.GetAxis(horizontal));


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
