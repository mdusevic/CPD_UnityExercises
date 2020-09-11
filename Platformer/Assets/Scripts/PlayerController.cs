using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveForce;
    public float jumpForce;
    public float gravityScale;
    public CharacterController cb;
    private Vector3 moveDirection;

    private Touch touch;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cb = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(0f, moveDirection.y, Input.GetAxis("Horizontal") * moveForce);

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            MobileMovement();
        }

        Movement();
    }

    void Movement()
    {
        if (Input.GetButtonDown("Jump") && cb.isGrounded)
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        cb.Move(moveDirection * Time.deltaTime);
    }

    void MobileMovement()
    {
        Vector3 acc = Input.acceleration;

        if (Input.touchCount > 0 && cb.isGrounded)
        {
            touch = Input.GetTouch(0);
            moveDirection.y = jumpForce;
        }

        cb.Move(new Vector3(0, 0, acc.x * moveForce) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "InvisiblePlatform")
        {
            collision.collider.gameObject.SetActive(false);
        }
    }
}