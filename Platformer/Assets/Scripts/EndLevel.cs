using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject endLevelUI;

    // Start is called before the first frame update
    void Start()
    {
        endLevelUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            endLevelUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
