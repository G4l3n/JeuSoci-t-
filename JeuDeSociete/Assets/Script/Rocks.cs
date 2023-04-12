using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float speed = 5f;
    public int lifetime = 5;
    private void Start()
    {
        Invoke("DestroyThis", lifetime);
    }
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
