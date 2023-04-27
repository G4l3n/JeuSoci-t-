using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PuzzleManager : MonoBehaviour
{
    public GameObject PuzzleKirby;
    public GameObject PuzzleNinin;
    public GameObject PuzzlePatrick;
    public Button Piece1;
    public Button Piece2;
    public Button Piece3;

    public TextMeshProUGUI CounterText;
    public int counter = 5;

    public int RandomPuzzle;
    public int RandomPiece;

    public List <Sprite> spritePiece;

    //Décompte avant la partie
    public bool startGame = false;
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject go;
    public void Start()
    {
        StartCoroutine(StartGame());
    }
    public void Puzzle()
    {
        StartCoroutine(CounterPuzzle());
        Debug.Log("start");
        RandomPuzzle = Random.Range(0, 2);

        if (RandomPuzzle == 0)
        {
            PuzzleKirby.SetActive(true);
            RandomPiece = Random.Range(0, 2);

            if (RandomPiece == 0)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[0];
                Piece1.gameObject.tag = "Piece";
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[1];
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[2];
            }
            if (RandomPiece == 1)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[3];
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[1];
                Piece2.gameObject.tag = "Piece";
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[2];
            }
            if (RandomPiece == 2)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[2];
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[3];
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[1];
                Piece3.gameObject.tag = "Piece";
            }
        }

        if (RandomPuzzle == 1)
        {
            PuzzleNinin.SetActive(true);
            RandomPiece = Random.Range(0, 2);

            if (RandomPiece == 0)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[4];
                Piece1.gameObject.tag = "Piece";
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[5];
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[6];
            }
            if (RandomPiece == 1)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[6];
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[4];
                Piece2.gameObject.tag = "Piece";
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[5];
            }
            if (RandomPiece == 2)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[5];
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[6];
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[4];
                Piece3.gameObject.tag = "Piece";
            }
        }

        if (RandomPuzzle == 2)
        {
            PuzzlePatrick.SetActive(true);
            RandomPiece = Random.Range(0, 2);

            if (RandomPiece == 0)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[7];
                Piece1.gameObject.tag = "Piece";
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[8];
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[9];
            }
            if (RandomPiece == 1)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[9];
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[7];
                Piece2.gameObject.tag = "Piece";
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[8];
            }
            if (RandomPiece == 2)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = spritePiece[8];
                Piece2.GetComponent<SpriteRenderer>().sprite = spritePiece[9];
                Piece3.GetComponent<SpriteRenderer>().sprite = spritePiece[7];
                Piece3.gameObject.tag = "Piece";
            }
        }
    }
    public void GoodPiece()
    {
        if (tag == "Piece")
        {
            SceneManager.LoadScene("Victory");
        }

        if (tag != "Piece")
        {
            SceneManager.LoadScene("Defeat");
        }
    }
    IEnumerator CounterPuzzle()
    {
        Debug.Log("zrknhpzorh");
        CounterText.text = counter.ToString();
        yield return new WaitForSeconds(1);
        counter--;

        if (counter >= 0)
        {
            StartCoroutine(CounterPuzzle());
        }
        if (counter <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
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

        Puzzle();
    }
}
