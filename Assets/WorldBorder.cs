using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        string tag = other.gameObject.tag;
        if (tag == "1" || tag == "2") {
            foreach (Target t in other.gameObject.GetComponentsInChildren<Target>()) {
                StartCoroutine(t.Die());
            }
        }
    }
}
