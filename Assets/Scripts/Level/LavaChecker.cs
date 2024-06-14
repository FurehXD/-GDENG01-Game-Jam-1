using UnityEngine;

public class LavaCollision : MonoBehaviour
{
    [SerializeField]
    private Transform _startPosition;
    [SerializeField]
    private GameObject gameOverUI;  // Assign in inspector, should contain the buttons

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

        // Initially hide the game over UI
        gameOverUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure the player GameObject is tagged with "Player"
        {
            Debug.Log("Game Over!");
            gameOverUI.SetActive(true); // Show the game over UI

            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enableMovement = false;  // Disable player movement
            }

            // Unlock and show the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
