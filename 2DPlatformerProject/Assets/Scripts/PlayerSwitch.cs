using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class PlayerSwitch : MonoBehaviour
{
    public GameObject JORGEPlayerContainer;
    public GameObject BOBPlayerContainer;


    // Start is called before the first frame update
    void Start()
    {
        JORGEPlayerContainer.SetActive(true);
        BOBPlayerContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchJORGEtoBOB();
        SwitchBOBtoJORGE();
    }

    void SwitchJORGEtoBOB()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            JORGEPlayerContainer.SetActive(false);
            BOBPlayerContainer.SetActive(true);
        }
    }

    void SwitchBOBtoJORGE()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            JORGEPlayerContainer.SetActive(true);
            BOBPlayerContainer.SetActive(false);
        }
    }
}

