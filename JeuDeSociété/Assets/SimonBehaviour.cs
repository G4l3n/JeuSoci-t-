using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class SimonBehaviour : MonoBehaviour
{
    public int simonNumber = 5;

    public GameObject startButton;
    public GameObject[] buttonsTab;

    private int[] sequence;
    private int playerIndex = 0;

    void Start()
    {
        sequence = new int[simonNumber];

        foreach (GameObject button in buttonsTab)
        {
            button.SetActive(false);
        }
        startButton.SetActive(true);
    }


    public void StartGame()
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
            Lose();
        } else
        {
            playerIndex += 1;
        }

        if (playerIndex >= sequence.Length)
        {
            Win();
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

    public void Lose()
    {
        //Redesactive tous les boutons
        
        foreach (GameObject button in buttonsTab)
        {
            button.GetComponent<Button>().interactable = false;
        }
        

        Debug.Log("You lose");
    }

    public void Win()
    {
        //Redesactive tous les boutons
        foreach (GameObject button in buttonsTab)
        {
            button.GetComponent<Button>().interactable = false;
        }
        Debug.Log("You win");

        //SceneManager.LoadScene("NomDeLaScene");
        
    }

}
