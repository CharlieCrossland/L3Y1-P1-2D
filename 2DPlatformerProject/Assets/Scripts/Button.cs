using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jorge") || other.gameObject.CompareTag("Bob") || other.gameObject.CompareTag("Bullet"))
        {
            Door.SetActive(false);
        }
        else
        {
            Door.SetActive(true);
        }
    }



}
