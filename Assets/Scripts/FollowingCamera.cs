using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 0.9f;
    [SerializeField] float rotationDamp = 0.9f;

    Vector3 velocity = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Linearly interpolate between old camera position and new camera position
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 currPos = Vector3.Lerp(toPos, transform.position, distanceDamp);
        transform.position = currPos;

        // Linearly interpolate between old camera rotation and new camera rotation
        Vector3 currUp = Vector3.Lerp(target.up, transform.up, rotationDamp);
        transform.LookAt(target, currUp);
    }
}
