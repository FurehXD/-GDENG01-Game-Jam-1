using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 5f;
    public Transform carryPosition;

    private IInteractable currentInteractable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentInteractable == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
                {
                    currentInteractable = hit.collider.GetComponent<IInteractable>();
                    if (currentInteractable != null)
                    {
                        currentInteractable.Interact(carryPosition);
                    }
                }
            }
            else
            {
                currentInteractable.StopInteract();
                currentInteractable = null;
            }
        }
    }
}
