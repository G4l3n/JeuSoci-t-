using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public int speed;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }
}
