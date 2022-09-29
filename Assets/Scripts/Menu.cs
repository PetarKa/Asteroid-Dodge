using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject about;
    public GameObject exit;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        menu.SetActive(false);
        exit.SetActive(true);
    }

    public void About()
    {
        menu.SetActive(false);
        about.SetActive(true);
    }

    public void Back()
    {
        menu.SetActive(true);
        about.SetActive(false);
    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        exit.SetActive(false);
        menu.SetActive(true);
    }

}
