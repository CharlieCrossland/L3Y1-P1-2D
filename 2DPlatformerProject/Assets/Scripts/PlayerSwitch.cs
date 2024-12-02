using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class PlayerSwitch : MonoBehaviour
{
    public GameObject JORGEPlayerContainer;
    public GameObject BOBPlayerContainer;

    bool firstActive;

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
        if (Input.GetKeyDown(KeyCode.C))
        {
            firstActive = !firstActive;
        }

        JORGEPlayerContainer.SetActive(firstActive);
        BOBPlayerContainer.SetActive(!firstActive);
    }
}

