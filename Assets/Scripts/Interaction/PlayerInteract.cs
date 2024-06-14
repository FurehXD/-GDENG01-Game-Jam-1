using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 5f;
    public float interactRadius = 0.5f;  // The radius for the sphere cast
    public Transform carryPosition;      // Position where the object will be carried

    private IInteractable currentInteractable;  // Currently interacting object

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            // Adjust the origin to be slightly in front of the player
            Vector3 castOrigin = transform.position + transform.forward * 0.5f;

            // Visualize the SphereCast with a debug line
            Debug.DrawRay(castOrigin, transform.forward * interactDistance, Color.blue, 2.0f);

            // Perform a SphereCast from the adjusted origin
            if (Physics.SphereCast(castOrigin, interactRadius, transform.forward, out hit, interactDistance))
            {
                // Debug line to show where the hit occurs
                Debug.DrawLine(castOrigin, hit.point, Color.red, 2.0f);

                // Attempt to get the IInteractable component from the hit object
                currentInteractable = hit.collider.GetComponent<IInteractable>();
                if (currentInteractable != null)
                {
                    currentInteractable.Interact(carryPosition);
                }
            }
            else
            {
                // If currently carrying an object and no new object was hit, stop interacting
                if (currentInteractable != null)
                {
                    currentInteractable.StopInteract();
                    currentInteractable = null;
                }
            }
        }
    }
}
