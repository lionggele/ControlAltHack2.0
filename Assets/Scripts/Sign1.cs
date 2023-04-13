using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sign1 : MonoBehaviour{

    public GameObject[] dialogBoxes;
    public GameObject[] targetObjects;
    //public TMP_Text dialogText;
    public string dialog;
    public bool playerInRange;
    public float range = 2.0f;
    public KeyCode toggleKey = KeyCode.M;

    // Use this for initialization
    void Start () {
        //dialogText.text ="";

        foreach (GameObject dialogBox in dialogBoxes) {
            dialogBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        if(playerInRange && Input.GetKeyDown(toggleKey))
        {
            for (int i = 0; i < dialogBoxes.Length; i++) {
                GameObject dialogBox = dialogBoxes[i];
                GameObject targetObject = targetObjects[i];

                if (Vector2.Distance(transform.position, targetObject.transform.position) < range) {
                    dialogBox.SetActive(!dialogBox.activeSelf);


                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("player")){
            playerInRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("player")){
            playerInRange = false;            
        }
    }
}
