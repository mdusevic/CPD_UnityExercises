using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 0.5f;
    public int scoreCount = 0;

    private Rigidbody rb;
    private CharacterController cb;

    public GameObject GoodPanel;
    public GameObject BadPanel;

    private Vector3 startPos;
    public Material collectMaterial;

    public KeyCode RestartKey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cb = GetComponent<CharacterController>();

        startPos = transform.position;

        if (rb == null)
        {
            Debug.LogError("Player Controller requires a Rigidbody");
        }

        GoodPanel.gameObject.SetActive(false);
        BadPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputForce = new Vector3();
        //inputForce.x = Input.GetAxis("Horizontal");
        inputForce.z = Input.GetAxis("Vertical");

        Vector3 forward = Vector3.Cross(Vector3.up, Camera.main.transform.right) * inputForce.z; ;
        cb.Move(forward * -moveForce);

        //Vector3 side = Vector3.Cross(Vector3.up, Camera.main.transform.forward) * inputForce.x; ;
        //cb.Move(side * moveForce);

        if (Input.GetKey(RestartKey))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            BadPanel.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void OnTriggerEnter(Collider gemCol)
    {
        if (gemCol.gameObject.tag == "Gem")
        {
            gemCol.GetComponent<Renderer>().material = collectMaterial;

            Destroy(gemCol.gameObject, 0.25f);

            scoreCount++;
            
            if (scoreCount/2 == 49)
            {
                GoodPanel.gameObject.SetActive(true);

                Time.timeScale = 0;
            }
        }
    }
}
