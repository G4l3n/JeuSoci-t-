using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxe2 : MonoBehaviour
{
    public float pos2X, pos2Y;

    void Start()
    {
        
    }

    void Update()
    {
        pos2X = transform.position.x + 19;
        pos2Y = transform.position.y;
    }
}
