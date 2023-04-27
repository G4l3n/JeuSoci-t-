using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Enemy enemy;
    public int score;
    public bool destroyEnnemy = false;

    //Décompte avant la partie
    public bool startGame = false;
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject go;


    void Start()
    {
        StartCoroutine(StartGame());
        score = 0;
        initialPos = circle.transform.position;
    }
    void Update()
    {
        if (startGame)
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

            if (destroyEnnemy)
            {
                score = score + 1;
                if (score <= 10)
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
                SceneManager.LoadScene("Victory");
            }
        }
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }

    IEnumerator StartGame()
    {
        number3.SetActive(true);
        yield return new WaitForSeconds(1);
        number3.SetActive(false);
        number2.SetActive(true);
        yield return new WaitForSeconds(1);
        number2.SetActive(false);
        number1.SetActive(true);
        yield return new WaitForSeconds(1);
        number1.SetActive(false);
        go.SetActive(true);
        yield return new WaitForSeconds(1);
        go.SetActive(false);

        startGame = true;
    }
}