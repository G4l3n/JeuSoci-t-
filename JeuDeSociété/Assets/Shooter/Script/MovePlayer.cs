using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovePlayer : MonoBehaviour
{
    public Transform player;
    public bool touchStart = false;
    public float speed = 5.0f;
    private Vector2 pointA, pointB, initialPos;

    public Transform circle;
    public Transform outerCircle;

    public Projectile projectil;
    public HealthPlayer healthP;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI Win;
    public Enemy enemy;
    public int score;
    public bool destroyEnnemy = false;


    void Start()
    {
        score = 0;
        initialPos = circle.transform.position;
    }
    void Update()
    {
        if(destroyEnnemy)
        {
            score = score +1;
            Debug.Log(score);
            if(score <= 10)
            {
                Score.text = "Score : " + score.ToString();
            }
            destroyEnnemy = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            circle.transform.position = pointA * -1;
        }

        if (Input.GetMouseButton(0))
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
        if (healthP.life == false || score == 10)
        {
            speed = 0;
        }
        if (score == 10)
        {
            Win.text = "Gagné !";
        }
    }

    private void FixedUpdate()
    {
        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * 1);
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
        }
        else
        {
            circle.transform.position = initialPos;
        }
    }
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}