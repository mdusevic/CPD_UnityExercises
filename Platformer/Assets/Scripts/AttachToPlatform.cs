using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToPlatform : MonoBehaviour
{
    Transform originalParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<MovingPlatform>() != null)
        {
            originalParent = transform.parent;
            gameObject.transform.SetParent(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MovingPlatform>() != null)
        {
            gameObject.transform.SetParent(originalParent);
            originalParent = null;
        }
    }
}
