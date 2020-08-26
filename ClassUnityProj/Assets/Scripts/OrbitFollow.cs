using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed;
    public Vector3 offset;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        smoothSpeed = 0.2f;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, smoothSpeed * Time.deltaTime);
    }
}
