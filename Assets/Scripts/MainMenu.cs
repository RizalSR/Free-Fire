using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject Panelku;
    void Start()
    {
        Panelku = GameObject.Find("SettingPanel");
        Panelku.SetActive(false);
    }
    public void Menu()
    {

        SceneManager.LoadScene("MainMenu");
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
