using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objToSpawn;
    public float spawnInSeconds = 3.0f;
    public float spawnCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = spawnInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown < 0)
        {
            spawnCooldown = spawnInSeconds;
            var obj = GameObject.Instantiate(objToSpawn);
            obj.transform.position = transform.position;
        }
    }
}
