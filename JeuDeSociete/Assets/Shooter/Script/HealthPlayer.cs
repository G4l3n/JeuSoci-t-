using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI LoseWin;
    public TextMeshProUGUI vie;
    public GameObject imageLoseWin;
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
                SceneManager.LoadScene("Defeat");
            }
        }
    }
}
