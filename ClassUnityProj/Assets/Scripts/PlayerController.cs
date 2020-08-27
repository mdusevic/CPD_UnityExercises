using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 1.0f;
    public int scoreCount = 0;

    private Rigidbody rb;
    private CharacterController cb;

    public GameObject GoodPanel;
    public GameObject BadPanel;

    private Vector3 startPos;

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
        inputForce.x = Input.GetAxis("Horizontal");
        inputForce.z = Input.GetAxis("Vertical");

        Vector3 forward = Vector3.Cross(Vector3.up, Camera.main.transform.right) * inputForce.z; ;
        cb.Move(forward * -moveForce);

        Vector3 side = Vector3.Cross(Vector3.up, Camera.main.transform.forward) * inputForce.x; ;
        cb.Move(side * moveForce);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            BadPanel.gameObject.SetActive(true);

            Time.timeScale = 0;

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void OnTriggerEnter(Collider gemCol)
    {
        if (gemCol.gameObject.tag == "Gem")
        {
            Destroy(gemCol.gameObject);
            scoreCount++;
            
            if (scoreCount == 49)
            {
                GoodPanel.gameObject.SetActive(true);

                Time.timeScale = 0;

                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }

}
