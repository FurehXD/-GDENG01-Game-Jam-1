using UnityEngine;

public interface IInteractable
{
    void Interact(Transform carryPosition);
    void StopInteract();
}
