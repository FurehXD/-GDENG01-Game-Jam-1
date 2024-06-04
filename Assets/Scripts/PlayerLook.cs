using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody; // Reference to the player's body
    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Calculating X axis rotation for looking up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limiting rotation to avoid flipping

        // Apply rotation for looking up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Apply rotation for turning left and right
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
