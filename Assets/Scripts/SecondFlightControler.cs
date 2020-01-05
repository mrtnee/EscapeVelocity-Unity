using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFlightControler : MonoBehaviour
{
    /*
     * [SerializeField]
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
    */

    public float speed = 90.0f;

    public KeyCode up_mine;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public string vertical;
    public string horizontal;
    public string shoot;
    public string nitro;
    // public KeyCode shoot;
    // public KeyCode nitro; // for more speed

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


        //if (Input.GetKeyDown(KeyCode.up))
        //if (Event.current.Equals(Event.KeyboardEvent(up)))
        /*
        if (up_mine.Equals("w"))
        {
            Console.WriteLine("NEKI");
        }
        */

        if (Input.GetKey(up_mine) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))
        {
            transform.Rotate(Input.GetAxis(vertical), 0.0f, -Input.GetAxis(horizontal));
        }

        /*
        if (up_mine.Equals("w") && Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
        }
        */


        float terrainHeightWherePlaneIs = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWherePlaneIs > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x,
                terrainHeightWherePlaneIs,
                transform.position.z);
            speed = 35.0f;
        }
    }

    /*
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())))
        {
            Debug.Log("Space key is pressed.");
        }
    }
    */
}
