using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private float jumpForce = 1.2f;
    private Rigidbody rb;
    private bool isGrounded = true;
    
    public void Jump()
    {
        GameObject sphere = GameObject.FindWithTag("Sphere");
        rb = sphere.GetComponent<Rigidbody>();
        if (isGrounded && rb != null)
        {
            Debug.Log("Jump + rb = " + rb );
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
