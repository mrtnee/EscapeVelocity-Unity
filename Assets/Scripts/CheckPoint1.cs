using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 1.0f, 0.0f);
        // transform.Rotation.x += 1.0f;
        // transform.Rotation.z += 1.0f; 

        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        // GameObject child = ParentGameObject.transform.GetChild(0).gameObject;
        // GameObject child = gameObject.GetChild(0);
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "1")
        {
            Debug.Log("1");
            // child.GetComponent<Renderer>().material.color = Color.blue;
            //If the GameObject's name matches the one you suggest, output this message in the console
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "2")
        {
            Debug.Log("2");
            //If the GameObject has the same tag as specified, output this message in the console
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            // child.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
