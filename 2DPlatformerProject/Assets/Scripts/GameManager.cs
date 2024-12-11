using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas inGame;
    public Canvas inGameJorge;
    public Canvas pauseMenu;

    public PlayerSwitch switchScript;
    public JORGEPlayerController JorgeScript;

    public TMP_Text timerTxt;
    public float timer;
    public GameObject Jorge;
    public GameObject Bob;

    bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        inGameJorge.enabled = true;
        inGame.enabled = false;
        pauseMenu.enabled = false;
        timer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
        }

        if (gamePaused)
        {
            Time.timeScale = 0f;
            inGame.enabled = false;
            inGameJorge.enabled = false;
            pauseMenu.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenu.enabled = false;
            
            if (switchScript.jorgeEnabled == true)
            {
                inGameJorge.enabled = true;
                inGame.enabled = false;
            }
            else
            {
                inGameJorge.enabled = false;
                inGame.enabled = true;
                timer = 10f;
            }
        }
        TimeOut();
    }
    void TimeOut()
    {
        timer -= Time.deltaTime;
        timerTxt.text = timer.ToString("F2");

        if (timer <= 0.0f)
        {
            Jorge.transform.GetChild(0).transform.position = Bob.transform.GetChild(0).transform.position;
            timer = 10f;
        }
    }
}
