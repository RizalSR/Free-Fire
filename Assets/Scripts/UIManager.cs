using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static int score;
    public Text ScoreText;
    public Text AmmoText;


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score : " + score;
        AmmoText.text = WeaponController.ammo + "/" + WeaponController.ammoMag;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Keluar Permainan");
        Application.Quit();
    }
}
