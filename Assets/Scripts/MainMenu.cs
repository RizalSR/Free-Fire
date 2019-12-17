using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Panelku;
    void Start()
    {
        
    }
    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }

    public void Setting()
    {
        Panelku.SetActive(true);
    }

    public void Back()
    {
        Panelku.SetActive(false);
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
