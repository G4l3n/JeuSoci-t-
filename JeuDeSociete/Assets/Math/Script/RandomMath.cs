using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMath : MonoBehaviour
{
    public Dictionary<string, string> dicoCalcule = new Dictionary<string, string>();
    public TextMeshProUGUI Calcule;
    public TextMeshProUGUI CounterText;
    public TextMeshProUGUI Rep1;
    public TextMeshProUGUI Rep2;
    public TextMeshProUGUI Rep3;
    private List<int> Reponse = new List<int> { 49, 20, 16, 58, -1, 3, 10, 26 };

    public int counter = 20;
    public int randomCalcule;
    public string Rep;
    public int randomRep1;
    public int randomRep2;
    public int randomRepText;

    public bool calculeFini;
    public int NumberRep;

    //D�compte avant la partie
    public bool startGame = false;
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject go;
    void Start()
    {
        StartCoroutine(StartGame());

        dicoCalcule.Add("3+5*2", "13");
        dicoCalcule.Add("8*7", "56");
        dicoCalcule.Add("2x+6 = 3+x", "-3");
        dicoCalcule.Add("5/(2+1*3)", "1");
        dicoCalcule.Add("6*3", "18");
        dicoCalcule.Add("3-(-4+1)", "6");
        calculeFini = true;
    }
    void Update()
    {
        if (startGame)
        {
            if (calculeFini)
            {
                RandomCalcule();
            }
            if (NumberRep == 3)
            {
                StopCoroutine(Counter());
                //BackroundFin.SetActive(true);
                //TextLoseWin.text = "Gagn� !";
                SceneManager.LoadScene("Victory");

            }
        }
    }
    void RandomCalcule()
    {
        calculeFini = false;
        randomCalcule = Random.Range(0, 5);

        var randomValues = dicoCalcule.Keys.ElementAt((int)Random.Range(0, dicoCalcule.Values.Count - randomCalcule));
        Rep = dicoCalcule[randomValues];
        Calcule.text = randomValues;
        dicoCalcule.Remove(randomValues);

        StartCoroutine(Counter());

        randomRepText = Random.Range(0, 2);

        if (randomRepText == 0)
        {
            randomRep1 = Random.Range(0, 7);
            Rep1.text = Reponse[randomRep1].ToString();
            randomRep2 = Random.Range(0, 7);
            if (randomRep2 == randomRep1)
            {
                randomRep2 = Random.Range(0, 7);

                if (randomRep2 == randomRep1)
                {
                    randomRep2 = Random.Range(0, 7);
                }
            }
            Rep2.text = Reponse[randomRep2].ToString();
            Rep3.text = Rep;
        }

        if (randomRepText == 1)
        {
            randomRep1 = Random.Range(0, 7);
            Rep2.text = Reponse[randomRep1].ToString();
            randomRep2 = Random.Range(0, 7);
            if (randomRep2 == randomRep1)
            {
                randomRep2 = Random.Range(0, 7);

                if (randomRep2 == randomRep1)
                {
                    randomRep2 = Random.Range(0, 7);
                }
            }
            Rep3.text = Reponse[randomRep2].ToString();
            Rep1.text = Rep;
        }

        if (randomRepText == 2)
        {
            randomRep1 = Random.Range(0, 7);
            Rep3.text = Reponse[randomRep1].ToString();
            randomRep2 = Random.Range(0, 7);
            if (randomRep2 == randomRep1)
            {
                randomRep2 = Random.Range(0, 7);

                if (randomRep2 == randomRep1)
                {
                    randomRep2 = Random.Range(0, 7);
                }
            }
            Rep1.text = Reponse[randomRep2].ToString();
            Rep2.text = Rep;
        }
    }

    public void Reponse1()
    {
        if (Rep1.text == Rep)
        {
            NumberRep++;
            calculeFini = true;
        }
        if (Rep1.text != Rep)
        {
            SceneManager.LoadScene("Defeat");

        }
    }
    public void Reponse2()
    {
        if (Rep2.text == Rep)
        {
            NumberRep++;
            calculeFini = true;
        }
        if (Rep2.text != Rep)
        {
            SceneManager.LoadScene("Defeat");
        }
    }
    public void Reponse3()
    {
        if (Rep3.text == Rep)
        {
            NumberRep++;
            calculeFini = true;
        }
        if (Rep3.text != Rep)
        {
            SceneManager.LoadScene("Defeat");
        }
    }

    IEnumerator Counter()
    {
        CounterText.text = counter.ToString();
        yield return new WaitForSeconds(1);
        counter--;

        if (counter >= 0)
        {
            StartCoroutine(Counter());
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
    }
}
