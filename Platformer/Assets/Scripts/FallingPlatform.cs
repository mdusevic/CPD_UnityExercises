using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material[] newMaterial;
    Material[] originMaterial;

    private int switchCount;

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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (switchCount == 0)
            {
                meshRenderer.materials = newMaterial;
                switchCount++;
                return;
            }

            if (switchCount >= 1)
            {
                Destroy(gameObject, 0.8f);
                switchCount = 0;
                return;
            }
        }
    }
}