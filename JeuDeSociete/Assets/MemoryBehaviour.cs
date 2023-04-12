using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBehaviour : MonoBehaviour
{
    public GameObject[] buttons;
    public Image[] images;
    public Sprite[] sprites;

    public int[] pressValues = { -1, -1 };
    public int[] buttonPressed = {-1, -1 };

    //Uses the buttonValue given by the order of the button to find its hidden value (needs to be initialized because of unoptomised code)
    private int[] valueTranslator = { 0, 0, 1, 1, 2, 2 , 3, 3, 4, 4, 5, 5};

    // Start is called before the first frame update
    void Start()
    {
        ShuffleCards();

        for (int i = 0; i < buttons.Length; i++)
        {
            images[i].sprite = sprites[valueTranslator[i]];
        }
    }

    public void ShuffleCards()
    {
        int tmp = 0;
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < 50; i++)
        {
            index1 = Random.Range(0, valueTranslator.Length);
            index2 = Random.Range(0, valueTranslator.Length);

            tmp = valueTranslator[index1];
            valueTranslator[index1] = valueTranslator[index2];
            valueTranslator[index2] = tmp;
        }
    }

    public void ButtonClick(int buttonValue)
    {
        buttons[buttonValue].gameObject.SetActive(false);
        Debug.Log(buttonValue);

        if (buttonPressed[0] == -1)
        {
            pressValues[0] = valueTranslator[buttonValue];
            buttonPressed[0] = buttonValue;
        }
        else
        {
            pressValues[1] = valueTranslator[buttonValue];
            buttonPressed[1] = buttonValue;
            CheckPair();
        }
    }

    public void CheckPair()
    {
        if (pressValues[0] == pressValues[1])
        {
            Debug.Log("Pair");
        }
        else
        {
            Debug.Log("NotPair");
            StartCoroutine(FlipDelay());
        }

        buttonPressed[0] = -1;
        buttonPressed[1] = -1;
    }

    public IEnumerator FlipDelay()
    {
        int button1 = buttonPressed[0];
        int button2 = buttonPressed[1];

        yield return new WaitForSeconds((float)0.5);

        buttons[button1].gameObject.SetActive(true);
        buttons[button2].gameObject.SetActive(true);
    }
}
