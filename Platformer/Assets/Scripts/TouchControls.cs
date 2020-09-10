using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    [SerializeField]
    public CharacterController cb;

    private float moveForce;
    private float jumpForce;
    private float gravityScale;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        PlayerController playerScript = player.GetComponent<PlayerController>();
        moveForce = playerScript.moveForce;
        jumpForce = playerScript.jumpForce;
        gravityScale = playerScript.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TouchLeft()
    {
        moveDirection = new Vector3(0f, moveDirection.y, Input.GetAxis("Horizontal") * moveForce);
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        cb.Move(-moveDirection * Time.deltaTime);
    }

    public void TouchRight()
    {
        moveDirection = new Vector3(0f, moveDirection.y, Input.GetAxis("Horizontal") * moveForce);
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        cb.Move(moveDirection * Time.deltaTime);
    }

    public void TouchJump()
    {
        moveDirection = new Vector3(0f, moveDirection.y, Input.GetAxis("Horizontal") * moveForce);
        if (cb.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
    }
}
