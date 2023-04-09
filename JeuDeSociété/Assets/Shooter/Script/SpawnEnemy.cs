using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Ennemy;
    public HealthPlayer healthP;
    public float wait;

    public MovePlayer player;

    void Start()
    {
        if (healthP.life)
        {
            Spawn();
        }
    }

    void Update()
    {
        if (healthP.life == false || player.score == 10)
        {
            StopCoroutine(SpawnEnnemy());
        }
    }
    public void Spawn()
    {
        StartCoroutine(SpawnEnnemy());
    }
    IEnumerator SpawnEnnemy()
    {
        yield return new WaitForSeconds(wait);
        Ennemy.SetActive(true);
        Instantiate(Ennemy, this.transform.position, transform.rotation, transform);
        Spawn();
    }
}