using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 2.0f;
    public float jumpForce = 5.0f;

    private Rigidbody rb;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;

        if (rb == null)
        {
            Debug.LogError("Player Controller requires a Rigidbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputForce = new Vector3();
        inputForce.x = Input.GetAxis("Horizontal");
        inputForce.z = Input.GetAxis("Vertical");
        rb.AddForce(inputForce * moveForce);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = startPos;
        }
    }
}
