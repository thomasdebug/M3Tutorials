using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class MoveBasic : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    private float speed = 5.0f; // Set player's movement speed.
    public Rigidbody rb; // Reference to player's Rigidbody.
    public bool onFloor;
    [SerializeField] private float rotSpeed = 50f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            onFloor = true;
        }
    }

    void Update()
    {
        Vector3 positionUpdate = transform.position + Input.GetAxis("Vertical") * transform.forward * speed * Time.deltaTime;
        transform.position = positionUpdate;
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0));
        if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            onFloor = false;
        }
    }
}
