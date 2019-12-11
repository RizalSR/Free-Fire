using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Keluar Permainan");
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Main");
    }
}
