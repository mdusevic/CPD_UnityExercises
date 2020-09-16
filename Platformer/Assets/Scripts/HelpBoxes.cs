using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBoxes : MonoBehaviour
{
    public GameObject helpboxUI;

    // Start is called before the first frame update
    void Start()
    {
        helpboxUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            helpboxUI.SetActive(false);
        }
    }

    public void Show()
    {
        helpboxUI.SetActive(true);
    }

    public void Hide()
    {
        helpboxUI.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            helpboxUI.SetActive(true);
        }
    }
}
