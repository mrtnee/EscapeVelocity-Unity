using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    private double lastAirCraftTrough = 0; // index of an aircraft, that went trough the check point last
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 1.0f, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager script = gameManager.GetComponent<GameManager>();

        if (other.gameObject.tag.Equals("1") && lastAirCraftTrough != 1)
        {
            
            // if checkPoint was white, when plane accomodated it, we add points to the plane that accomodated it
            if (lastAirCraftTrough == 0 && script != null)
            {
                script.checkPointReached(1, 1);
            }
            // if checkPoint was beforehand accomodated by other plane, we have to remove one point from the plane that previously owned it
            else if (lastAirCraftTrough == 2 && script != null)
            {
                // add point to plane that just reached checkPoint
                script.checkPointReached(1, 1);
                // remove point of a plane that reached checkPoint before
                script.checkPointReached(2, -1);
            }

            // this plane was last to conquer this checkPoint
            lastAirCraftTrough = 1;

            // change checkPoint's color
            var cubeRenderer = gameObject.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", new Color(53f / 255f, 107f / 255f, 255f / 255f));
        }
        else if (other.gameObject.tag.Equals("2") && lastAirCraftTrough != 2)
        {
            // if checkPoint was white, when plane accomodated it, we add points to the plane that accomodated it
            if (lastAirCraftTrough == 0 && script != null)
            {
                script.checkPointReached(2, 1);
            }
            // if checkPoint was beforehand accomodated by other plane, we have to remove one point from the plane that previously owned it
            else if (lastAirCraftTrough == 1 && script != null)
            {
                // add point to plane that just reached checkPoint
                script.checkPointReached(2, 1);
                // remove point of a plane that reached checkPoint before
                script.checkPointReached(1, -1);
            }

            // this plane was last to conquer this checkPoint
            lastAirCraftTrough = 2;

            // change checkPoint's color
            var cubeRenderer = gameObject.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", new Color(255f / 255f, 188f / 255f, 53f / 255f));
        }
    }
}
