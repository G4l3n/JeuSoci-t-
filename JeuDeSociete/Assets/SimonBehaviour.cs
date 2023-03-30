using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using TMPro;

public class SimonBehaviour : MonoBehaviour
{
    public int simonNumber = 5;

    public GameObject startButton;
    public GameObject[] buttonsTab;

    private int[] sequence;
    private int playerIndex = 0;

    [SerializeField] private TMP_Text startText;

    void Start()
    {
        DefaultState();
    }

    private void DefaultState()
    {
        playerIndex = 0;

        startText.text = $"Start";
        startButton.GetComponent<Button>().interactable = true;
        startButton.SetActive(true);

        foreach (GameObject button in buttonsTab)
        {
            button.SetActive(false);
        }
    }

    public void GameStart()
    {
        StartCoroutine(SequenceSelect());
    }

    IEnumerator SequenceSelect()
    {
        startButton.GetComponent<Button>().interactable = false;

        for (int i = 0; i < 50; i++)
        {
            startText.text = $"Sequence de {Random.Range(5, 10)}";
            yield return new WaitForSeconds((float)0.02);
        }

        int weight = Random.Range(0, 100);
        
        
        if (weight < 10)
        {
            simonNumber = 5;
        }
        else if (10 <= weight && weight < 50)
        {
            simonNumber = 6;
        }
        else if (50 <= weight && weight < 80)
        {
            simonNumber = 7;
        }
        else if (80 <= weight && weight < 95)
        {
            simonNumber = 8;
        }
        else if (95 <= weight && weight < 100)
        {
            simonNumber = 9;
        }

        sequence = new int[simonNumber];
        startText.text = $"Sequence de {simonNumber}";
        yield return new WaitForSeconds((float)3);

        startText.text = $"3";
        yield return new WaitForSeconds((float)0.7);

        startText.text = $"2";
        yield return new WaitForSeconds((float)0.7);

        startText.text = $"1";
        yield return new WaitForSeconds((float)0.7);

        startText.text = $"GO";
        yield return new WaitForSeconds((float)0.7);

        StartDisplay();
    }

    //public int GetRandomWeightedIndex(int[] weights)
    //{
    //    if (weights == null || weights.Length == 0) return -1;

    //    int t;
    //    int i;
    //    int w = 0;
    //    for (i = 0; i < weights.Length; i++)
    //    {
    //        if (weights[i] >= 0)
    //        { 
    //            w += weights[i];
    //        }
    //    }

    //    float r = Random.value;
    //    float s = 0f;

    //    for (i = 0; i < weights.Length; i++)
    //    {
    //        if (weights[i] <= 0f) continue;

    //        s += (float)weights[i] / w;
    //        if (s >= r) return i + 4;
    //    }

    //    return -1;
    //}


    public void StartDisplay()
    {
        //Affiche et desactive les boutons + Retire le bouton start
        foreach (GameObject button in buttonsTab)
        {
            button.SetActive(true);
            button.GetComponent<Button>().interactable = false;
        }
        startButton.SetActive(false);

        //Génère une séquence aléatoire de  la longueure de la séquence
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = Random.Range(0, 4);   //Nombre aléatoire de 0 à 3 (4 exclus)
        }

        //Appelle l'affichage de la séquence
        StartCoroutine(DisplaySimon());
    }


    IEnumerator DisplaySimon()
    {
        //Change 
        for (int i = 0; i < sequence.Length; i++)
        {
            Color initColor = buttonsTab[sequence[i]].GetComponent<Image>().color;
            buttonsTab[sequence[i]].GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds((float)0.2);
            buttonsTab[sequence[i]].GetComponent<Image>().color = initColor;
            yield return new WaitForSeconds((float)0.2);
        }

        
        //Active les boutons pour l'input du joueur
        foreach (GameObject button in buttonsTab)
        {
            button.GetComponent<Button>().interactable = true;
        }

        yield return null;
    }


    public void ButtonPress(int buttonValue)
    {
        StartCoroutine(ButtonAnimation(buttonValue));
        
        //Si l'input est différent de la séquence
        if (buttonValue != sequence[playerIndex])
        {
            StartCoroutine(Lose());
        } else
        {
            playerIndex += 1;
        }

        if (playerIndex >= sequence.Length)
        {
            StartCoroutine(Win());
        }
    }

    

    //Fait tourner le bouton blanc 
    IEnumerator ButtonAnimation(int i)
    {
        Color initColor = buttonsTab[i].GetComponent<Image>().color;
        buttonsTab[i].GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds((float)0.1);
        buttonsTab[i].GetComponent<Image>().color = initColor;
    }

    IEnumerator Lose()
    {

        Debug.Log("You lose");
        foreach (GameObject button in buttonsTab)
        {
            button.GetComponent<Button>().interactable = false;
        }
        startText.text = "U lose L";
        startButton.SetActive(true);
        yield return new WaitForSeconds((float)2);


        DefaultState();
        yield return null;
    }

    IEnumerator Win()
    {
        foreach (GameObject button in buttonsTab)
        {
            button.GetComponent<Button>().interactable = false;
        }
        startText.text = "U win";
        startButton.SetActive(true);

        yield return new WaitForSeconds((float)2);

        DefaultState();
        yield return null;
    }
}
