using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject aircraft;
    public ParticleSystem explosion;

    public float waitAfterDeath = 1.0f;
    private bool isCurrentlyDying = false;

    public IEnumerator Die() {
        // This target was already hit, don't play the explosion
        if (isCurrentlyDying)
            yield break;

        isCurrentlyDying = true;

        // Play the explosion particle system
        explosion.Play();

        // After explosion has finished, move the player to a new random position
        yield return new WaitForSeconds(waitAfterDeath);

        SetRandomPositionAboveWorld();

        isCurrentlyDying = false;
    }

    private void SetRandomPositionAboveWorld() {
        // Calculate random position and move the aircraft to specified position
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        Vector3 terrainPosition = Terrain.activeTerrain.GetPosition();

        float randomX = Random.Range(terrainPosition.x, terrainPosition.x + terrainData.size.x);
        float randomZ = Random.Range(terrainPosition.z, terrainPosition.z + terrainData.size.z);
        float positionY = Terrain.activeTerrain.SampleHeight(new Vector3(randomX, randomZ, 0));
        aircraft.transform.position = new Vector3(randomX, positionY + 5, randomZ);
    }

}