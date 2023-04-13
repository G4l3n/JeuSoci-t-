using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxe : MonoBehaviour
{

    private float length, start;
    public GameObject cam;
    public float parallaxeEffect;
    public Vector2 speed = new Vector2();
    public Vector2 direction = new Vector2();
    public Parallaxe2 position;

    void Start()
    {
        start = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        float temps = cam.transform.position.x * (1 - parallaxeEffect);
        float dist = cam.transform.position.x * parallaxeEffect;
        transform.position = new Vector3(start + dist, transform.position.y, transform.position.z);

        if (temps > start + length)
        {
            transform.position = new Vector2(position.pos2X, position.pos2Y);
        }

        else if (temps < start - length)
        {
            start -= length;
        }
    }
}
