using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveForce;
    [SerializeField] float jumpForce;

    private bool isGrounded = true;
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
        inputForce.z = Input.GetAxis("Horizontal");

        Vector3 forward = Vector3.Cross(Vector3.up, Camera.main.transform.forward) * inputForce.z; ;
        rb.AddForce(forward * moveForce);

        Jump();
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);

            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
