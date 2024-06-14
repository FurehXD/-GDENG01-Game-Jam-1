using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataSlotChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject DataComponentParent;
    [SerializeField]
    private GameObject DataSlotArea;
    [SerializeField]
    private TextMeshProUGUI amountText;
    [SerializeField]
    private GameObject winObject;

    private Collider dataSlotAreaCollider;

    void Start()
    {
        winObject.SetActive(false);
        dataSlotAreaCollider = DataSlotArea.GetComponent<Collider>();
        if (dataSlotAreaCollider == null)
        {
            Debug.LogError("DataSlotArea does not have a collider attached!");
        }
    }

    void Update()
    {
        int componentsOutside = 0;

        // Check each child component
        foreach (Transform child in DataComponentParent.transform)
        {
            Collider componentCollider = child.GetComponent<Collider>();
            if (componentCollider == null)
            {
                Debug.LogError("Child component missing Collider: " + child.name);
                continue;
            }

            if (!dataSlotAreaCollider.bounds.Intersects(componentCollider.bounds))
            {
                componentsOutside++;
            }
        }

        // Update the amount text with the number of components outside
        if (amountText != null)
        {
            amountText.text = componentsOutside.ToString();
        }
        else
        {
            Debug.LogError("Status TextMeshProUGUI component not assigned!");
        }

        // Check if no components are outside, and log "You Win"
        if (componentsOutside == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("You Win");
            winObject.SetActive(true);
        }
    }
}
