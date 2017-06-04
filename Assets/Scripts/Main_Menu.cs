using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    public string myScene;

    public void PlayGame()
    {
        SceneManager.LoadScene(myScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
