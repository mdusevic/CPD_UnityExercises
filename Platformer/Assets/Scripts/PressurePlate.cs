using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent m_movePlatform;

    MeshRenderer meshRenderer;
    Material[] newMaterial;
    Material[] originMaterial;

    public Vector3 target;
    public float speed;

    private bool movePlate = true;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Material[] materials = meshRenderer.materials;
        originMaterial = new Material[] { materials[0] };
        newMaterial = new Material[] { materials[1] };

        meshRenderer.materials = originMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (movePlate)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                movePlate = false;
            }

            meshRenderer.materials = newMaterial;

            m_movePlatform.Invoke();
        }
    }
}
