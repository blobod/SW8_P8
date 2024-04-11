using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the sphere
    private Rigidbody rb; // Reference to the sphere's Rigidbody component
    public InputAction moveAction; // Reference to the move InputAction

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable(); // Enable the InputAction
    }

    void FixedUpdate()
    {
        // Read the value from the InputAction
        Vector2 direction = moveAction.ReadValue<Vector2>();
        
        // Convert the 2D direction to a 3D vector, assuming you want to move on the XZ plane
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);

        // Apply the movement force to the sphere's Rigidbody
        rb.AddForce(moveDirection * speed);
    }

    void OnDisable()
    {
        moveAction.Disable(); // Disable the InputAction when the script is disabled
    }
}
