using UnityEngine;  
using UnityEngine.UI;
using System;


public class Flag : MonoBehaviour
{
    private static int totalFlagCount = 4;
    private int flagCount = 0;
    public Text dialogText;
    public GameObject door;


    private void Start()
    { 
        totalFlagCount++;
        door.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Destroy(gameObject); // Destroy the flag object
            IncreaseFlagCount();
        }
    }

    public void IncreaseFlagCount()
    {
        flagCount++;
        dialogText.text = "Flags collected: " + flagCount;

        if (flagCount == 4)
        {
            //Debug.Log("4Flag");
            door.SetActive(false);
        }
    }
}
