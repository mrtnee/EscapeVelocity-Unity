using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPlayerIndicator : MonoBehaviour
{
    public Transform player;
    Vector3 p;
    Vector3 r;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePosition();
        UpdateRotation();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        p = player.position;
        p.Set(p.x, transform.position.y, p.z);
        transform.position = p;
    }

    private void UpdateRotation()
    {
        r = player.eulerAngles;
        r.Set(transform.eulerAngles.x, r.y, transform.eulerAngles.z);
        transform.eulerAngles = r;
    }
}
