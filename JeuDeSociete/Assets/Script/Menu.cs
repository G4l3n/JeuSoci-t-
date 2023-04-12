using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string[] scene;
    public string randomScene;

    private void Start()
    {
        randomScene = scene[Random.Range(0, scene.Length)];
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(randomScene);
    }
}
