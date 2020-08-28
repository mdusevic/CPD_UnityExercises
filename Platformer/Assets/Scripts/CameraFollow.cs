using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player = null;
    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.z = (cameraOffset + player.transform.position).z;
        transform.position = currentPosition;
    }
}
