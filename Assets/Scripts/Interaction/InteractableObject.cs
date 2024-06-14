using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    private Transform carryPosition;
    private bool isBeingCarried = false;

    public void Interact(Transform carryPosition)
    {
        this.carryPosition = carryPosition; // Store the carry position
        isBeingCarried = true;              // Mark the object as being carried
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
            this.transform.position = carryPosition.position; // Continuously update position
        }
    }
}
