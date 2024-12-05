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
    bool JORGEdistance;
    bool BOBdistance;

    // Start is called before the first frame update
    void Start()
    {
        firstActive = true;

        // Disables Robot and enables Monster on level start
        JORGEPlayerContainer.SetActive(true);
        BOBPlayerContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && (JORGEdistance == true || BOBdistance == true))
        {
            firstActive = !firstActive;
            JORGEdistance = false;
        }

        JORGEPlayerContainer.SetActive(firstActive);
        BOBPlayerContainer.SetActive(!firstActive);


        if (BOBPlayerContainer.gameObject.activeSelf == true)
        {
            JORGEPlayerContainer.transform.GetChild(0).transform.position = BOBPlayerContainer.transform.GetChild(0).transform.position;
        }

        if (JORGEPlayerContainer.gameObject.activeSelf == true)
        {
            BOBInactive.transform.position = BOBPlayerContainer.transform.GetChild(0).transform.position;
        }
 
        UI();
    }

    void UI()
    {
        timer += Time.deltaTime;
        timerTxt.text = timer.ToString("F2");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jorge"))
        {
            JORGEdistance = true;
        }
        if (other.gameObject.CompareTag("Bob"))
        {
            BOBdistance = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jorge"))
        {
            JORGEdistance = false;
        }
        if (other.gameObject.CompareTag("Bob"))
        {
            BOBdistance = true;
        }    
    }
}
