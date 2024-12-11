using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;


public class PlayerSwitch : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text timerTxt;
    public float timer;

    [Header("Switch")]
    public GameObject JORGEPlayerContainer;
    public GameObject BOBPlayerContainer;
    public GameObject BOBInactive;

    bool firstActive;
    public bool JORGEdistance;
    public bool BOBdistance;
    public bool jorgeEnabled;

    // Start is called before the first frame update
    void Start()
    {
        firstActive = true;

        BOBdistance = true;

        // Disables Robot and enables Monster on level start
        JORGEPlayerContainer.SetActive(true);
        BOBPlayerContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && (JORGEdistance == true && BOBdistance == true))
        {
            firstActive = !firstActive;
        }

        JORGEPlayerContainer.SetActive(firstActive);
        BOBPlayerContainer.SetActive(!firstActive);


        if (BOBPlayerContainer.gameObject.activeSelf == true)
        {
            jorgeEnabled = false;
            JORGEPlayerContainer.transform.GetChild(0).transform.position = BOBPlayerContainer.transform.GetChild(0).transform.position;
        }

        if (JORGEPlayerContainer.gameObject.activeSelf == true)
        {
            jorgeEnabled = true;
            BOBInactive.transform.position = BOBPlayerContainer.transform.GetChild(0).transform.position;
        }
 
        UI();
    }

    void UI()
    {
        timer += Time.deltaTime;
        timerTxt.text = timer.ToString("F2");
    }
  
}
