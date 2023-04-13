using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool canJump = false;
    public float tapForce;
    private Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rocks")
        {
            Debug.Log("enter");
            Time.timeScale = 0;
            SceneManager.LoadScene("Defeat");
        }
    }
}
