using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Transform Player;
    public Camera FollowCam, TopDownCam;
    public KeyCode TKey;
    public bool camSwitch = false;

    void Update()
    {
        if (Input.GetKeyDown(TKey))
        {
            camSwitch = !camSwitch;
            TopDownCam.gameObject.SetActive(camSwitch);
            FollowCam.gameObject.SetActive(!camSwitch);
        }
    }
}
