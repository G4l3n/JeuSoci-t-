using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    public Vector2 speed = new Vector2();
    public Vector2 direction = new Vector2();
    public HealthPlayer healthP;

    public MovePlayer player;

    void Update()
    {
        if (healthP.life)
        {
            Vector3 mouvement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);
            mouvement *= Time.deltaTime;
            transform.Translate(mouvement);
        }
        if (healthP.life == false || player.score == 10)
        {
            Vector3 stop = new Vector3(0, 0, 0);
            stop *= Time.deltaTime;
            transform.Translate(stop);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PlayerProjectil")
        {
            player.destroyEnnemy = true;
            Destroy(this.gameObject);
        }
    }
}
