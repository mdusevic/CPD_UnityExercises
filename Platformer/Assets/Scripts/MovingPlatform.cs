using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    [SerializeField]
    public GameObject targetPos1;
    [SerializeField]
    public GameObject targetPos2;

    private Rigidbody rb;

    private bool firstMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        firstMove = true;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos1.transform.position, speed * Time.deltaTime);
        }

        if (!firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos2.transform.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "MovingPlatform" || collision.gameObject.tag == "InvisiblePlatform")
        {
            if (firstMove)
            {
                firstMove = false;
            }

            else
            {
                firstMove = true;
            }
        }
    }
}
