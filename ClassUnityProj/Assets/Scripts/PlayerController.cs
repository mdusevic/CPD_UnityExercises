using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 1.0f;
    public float jumpForce = 4.0f;

    private Rigidbody rb;

    public GameObject GoodPanel;
    public GameObject BadPanel;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        rb.AddForce(forward * -moveForce);

        Vector3 side = Vector3.Cross(Vector3.up, Camera.main.transform.forward) * inputForce.x; ;
        rb.AddForce(side * moveForce);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = startPos;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            BadPanel.gameObject.SetActive(true);

            Time.timeScale = 0;

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            GoodPanel.gameObject.SetActive(true);

            Time.timeScale = 0;

            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
