using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material[] newMaterial;
    Material[] originMaterial;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Material[] materials = meshRenderer.materials;
        originMaterial = new Material[] { materials[0] };
        newMaterial = new Material[] { materials[1] };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Set the new material on the GameObject
            meshRenderer.materials = newMaterial;
        }

        else
        {
            meshRenderer.materials = originMaterial;
        }
    }
}
