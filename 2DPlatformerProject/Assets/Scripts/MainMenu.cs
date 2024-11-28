using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    public Canvas main;
    public Canvas credits;


    // Start is called before the first frame update
    void Start()
    {
        main.enabled = true;
        credits.enabled = false;
    }

    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnCredits()
    {
        main.enabled = false;
        credits.enabled = true;
    }
    public void OnExit()
    {
        Application.Quit();
    }
    public void OnBackToMain()
    {
        main.enabled = true;
        credits.enabled = false;
    }
}
