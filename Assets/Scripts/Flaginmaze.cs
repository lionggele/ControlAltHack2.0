using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaginmaze : MonoBehaviour
{
    public GameObject door;
    private void Start()
    { 
        door.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Destroy(gameObject); // Destroy the flag object
        }
    }
}
