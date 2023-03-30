using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rocks;

    public float frequency = 1;

    public float RangMax;
    public float RangMin;

    private void Start()
    {
        if (Time.timeSinceLevelLoad < 5f)
        {
            InvokeRepeating("SpawnRocks", 1, frequency);
        }
    }
    void SpawnRocks()
    {
            Vector3 randomPos = new Vector3(transform.position.x, Random.Range(RangMin, RangMax), transform.position.z);

            Instantiate(rocks, randomPos, transform.rotation);
    }
}
