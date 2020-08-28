using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public GameObject targetPos1;
    public GameObject targetPos2;

    public GameObject player;

    private bool firstMove;

    private bool isMounted;
    private Vector3 offset;

    private Transform tr = null;

    void Start()
    {
        firstMove = true;

        isMounted = false;
    }

    void Update()
    {
        offset = transform.position - player.transform.position;
        Move();
    }

    void Move()
    {
        if (firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos1.transform.position, speed * Time.deltaTime);

            if (isMounted)
            {
                player.transform.position = transform.position + offset;
            }
        }

        if (!firstMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos2.transform.position, speed * Time.deltaTime);

            if (isMounted)
            {
                player.transform.position = transform.position + offset;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
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

        if (collision.gameObject.tag == "Player")
        {
            tr = collision.gameObject.transform.parent;
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(tr);
        }
    }
}
