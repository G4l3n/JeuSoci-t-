using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject PuzzleKirby;
    public GameObject PuzzleNinin;
    public GameObject PuzzlePatrick;
    public Button Piece1;
    public Button Piece2;
    public Button Piece3;

    public int RandomPuzzle;
    public int RandomPiece;

    public List <Sprite> Piece;
    public GameObject imageLoseWin;
    public TextMeshProUGUI LoseWin;
    public void Start()
    {
        RandomPuzzle = Random.Range(0, 2);

        if(RandomPuzzle == 0)
        {
            PuzzleKirby.SetActive(true);
            RandomPiece = Random.Range(0, 2);
            
            if(RandomPiece == 0)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[0];
                Piece1.gameObject.tag = "Piece";
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[1];
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[2];
            }
            if(RandomPiece == 1)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[3];
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[1];
                Piece2.gameObject.tag = "Piece";
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[2];
            }
            if(RandomPiece == 2)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[2];
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[3];
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[1];
                Piece3.gameObject.tag = "Piece";
            }
        }
        
        if(RandomPuzzle == 1)
        {
            PuzzleNinin.SetActive(true);
            RandomPiece = Random.Range(0, 2);

            if (RandomPiece == 0)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[4];
                Piece1.gameObject.tag = "Piece";
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[5];
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[6];
            }
            if (RandomPiece == 1)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[6];
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[4];
                Piece2.gameObject.tag = "Piece";
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[5];
            }
            if (RandomPiece == 2)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[5];
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[6];
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[4];
                Piece3.gameObject.tag = "Piece";
            }
        }

        if (RandomPuzzle == 2)
        {
            PuzzlePatrick.SetActive(true);
            RandomPiece = Random.Range(0, 2);

            if (RandomPiece == 0)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[7];
                Piece1.gameObject.tag = "Piece";
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[8];
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[9];
            }
            if (RandomPiece == 1)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[9];
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[7];
                Piece2.gameObject.tag = "Piece";
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[8];
            }
            if (RandomPiece == 2)
            {
                Piece1.GetComponent<SpriteRenderer>().sprite = Piece[8];
                Piece2.GetComponent<SpriteRenderer>().sprite = Piece[9];
                Piece3.GetComponent<SpriteRenderer>().sprite = Piece[7];
                Piece3.gameObject.tag = "Piece";
            }
        }
    }
    public void GoodPiece()
    {
        if (tag == "Piece")
        {
            imageLoseWin.SetActive(true);
            LoseWin.text = "Gagn� !";
        }
        
        if (tag != "Piece")
        {
            imageLoseWin.SetActive(true);
            LoseWin.text = "Perdu !";
        }
    }
}
