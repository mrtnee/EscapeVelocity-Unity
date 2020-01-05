using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public ParticleSystem explosion;

    public void Die() {
        // This function will be called when player is shot by their opponent

        // Play the explosion particle system
        explosion.Play();

        // After explosion has finished, move the player to a new random position
        
    }

}
