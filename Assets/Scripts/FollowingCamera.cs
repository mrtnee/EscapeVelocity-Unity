using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 2f, -10f);
    [SerializeField] float distanceDamp = 0.5f;
    [SerializeField] float rotationDamp = 0.5f;

    Vector3 velocity = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 currPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, distanceDamp);
        transform.position = currPos;

        transform.LookAt(target, target.up);
    }
}
