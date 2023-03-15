using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Sign1 : MonoBehaviour{

    public GameObject dialogBox;

    public string dialog;
    public bool playerInRange;
    
    
	// Use this for initialization
	void Start () {
        dialogBox.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        if(playerInRange && Input.GetKeyDown(KeyCode.M))
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }else{
                dialogBox.SetActive(true);
            }
        }
        
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("player")){
            playerInRange = true;
        }

    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player") /*&& !other.isTrigger*/)
        {
            playerInRange = false;
            
        }
    }

}