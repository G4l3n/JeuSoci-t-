using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class HealthPlayer : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI Perdu;
    public TextMeshProUGUI vie;
    public bool life = true;
    void Start()
    {
        health = 2;
    }
    void Update()
    {
        vie.text = "Vie : " + health.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            health--;

            if (health == 0)
            {
                life = false;
                Perdu.text = "Perdu !";
            }
        }
    }
}
