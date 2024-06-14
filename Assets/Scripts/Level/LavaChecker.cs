using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollision : MonoBehaviour
{
    private void Start()
    {
        // Ensure the collider of this lava plane is set to trigger
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Debug.LogError("Missing collider on lava plane: " + gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider belongs to the player
        if (other.CompareTag("Player")) // Ensure the player GameObject is tagged with "Player"
        {
            Debug.Log("Game Over!"); // Player has entered a lava plane
        }
    }
}
