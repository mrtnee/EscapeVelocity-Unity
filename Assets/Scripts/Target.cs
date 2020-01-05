using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void Die() {
        // This function will be called when player is shot by their opponent
        Debug.Log("HIT!");
    }

}
