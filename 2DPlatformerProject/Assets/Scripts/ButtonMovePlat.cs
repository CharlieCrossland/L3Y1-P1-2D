using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovePlat : MonoBehaviour
{
    public GameObject MovePlat;
    // Start is called before the first frame update
    void Start()
    {
        MovePlat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jorge") || other.gameObject.CompareTag("Bob") || other.gameObject.CompareTag("Bullet"))
        {
            MovePlat.SetActive(true);
        }
        else
        {
            MovePlat.SetActive(false);
        }
    }



}
