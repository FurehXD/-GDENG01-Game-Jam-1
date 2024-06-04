using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
    }

    private void FixedUpdate()
    {
        // Move the player using Rigidbody for consistent physics interaction
        rb.MovePosition(rb.position + transform.TransformDirection(movement) * speed * Time.fixedDeltaTime);
    }
}
