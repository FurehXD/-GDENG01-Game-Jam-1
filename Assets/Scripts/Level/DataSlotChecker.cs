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

    private Collider dataSlotAreaCollider; 

    void Start()
    {
        dataSlotAreaCollider = DataSlotArea.GetComponent<Collider>();
        if (dataSlotAreaCollider == null)
        {
            Debug.LogError("DataSlotArea does not have a collider attached!");
        }
    }

    void Update()
    {
        int componentsOutside = 0; 

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

        if (amountText != null)
        {
            amountText.text = componentsOutside.ToString();
        }
        else
        {
            Debug.LogError("Status TextMeshProUGUI component not assigned!");
        }
    }
}
