using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBehaviour : MonoBehaviour
{
    public GameObject[] buttons;

    public int firstPress = -1;
    public int secondPress = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick(int buttonValue)
    {
        buttons[buttonValue].gameObject.SetActive(false);

        if (firstPress == -1)
        {
            firstPress = buttonValue;
        }
        else
        {
            secondPress = buttonValue;
        }
    }

    public void CheckPair()
    {
        
    }
}
