using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float tapForce = 500;
    private Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerRigidbody.AddForce(Vector2.up * tapForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rocks")
        {
            Debug.Log("enter");
            Time.timeScale = 0;
            SceneManager.LoadScene("Menu");
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "rocks")
    //    {
    //        Debug.Log("enter");
    //        Time.timeScale = 0;
    //        SceneManager.LoadScene("Menu");
    //    }
    //}
}
