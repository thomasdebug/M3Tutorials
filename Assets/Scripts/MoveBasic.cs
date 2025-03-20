using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBasic : MonoBehaviour
{
    public float jumpForce = 2.0f;
    private float speed = 5.0f; // Set player's movement speed.
    public Rigidbody rb; // Reference to player's Rigidbody.
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    void Update()
    {




        if (Input.GetKey(KeyCode.D))
        {
            rb.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.position += Vector3.back * speed * Time.deltaTime;
        }
    }
}
