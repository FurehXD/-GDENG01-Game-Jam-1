using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Transform orientationTransform;
    private bool isBeingCarried = false;

    // Constructor to initialize with the player's orientation transform
    public void Interact(Transform carryPosition)
    {
        this.orientationTransform = carryPosition; // Store the orientation transform
        isBeingCarried = true;                     // Mark the object as being carried
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void StopInteract()
    {
        isBeingCarried = false; // Mark the object as no longer being carried
        this.GetComponent<Rigidbody>().isKinematic = false;
    }

    void Update()
    {
        if (isBeingCarried)
        {
            // Update position to be in front of the orientation transform
            this.transform.position = orientationTransform.position + orientationTransform.forward * 3.0f; // Adjust the distance
            this.transform.rotation = Quaternion.LookRotation(orientationTransform.forward); // Optionally, align rotation
        }
    }
}
