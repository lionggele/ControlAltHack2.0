using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;

public class Reenterpassword : MonoBehaviour
{
    public GameObject Reenterpasswords;
    public GameObject Success;
    public GameObject Failure;
    public TMP_InputField inputField;
    public Button submitButton;
    public bool playerInRange;
    public float range = 2.0f;
    public string userReInput = "";   
    public Password passwordScript;

    void Start()
    {
        Reenterpasswords.SetActive(false);
        Success.SetActive(false);
        Failure.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is with the desired object
        if (other.CompareTag("player"))
        {
            Reenterpasswords.SetActive(true);
            inputField.gameObject.SetActive(true);
            InputSystem.DisableDevice(Keyboard.current);
            submitButton.onClick.AddListener(SubmitInput);
            passwordScript = GameObject.Find("Password").GetComponent<Password>();
        }
    }
    void SubmitInput()
    {
        userReInput = inputField.text;        
        Debug.Log(inputField.text);
        Reenterpasswords.SetActive(false);
        inputField.gameObject.SetActive(false);
        InputSystem.EnableDevice(Keyboard.current);
        string reenteredPassword = inputField.text;
        string correctPassword = passwordScript.userInput;

        if (reenteredPassword == correctPassword)
        {
            Success.SetActive(true);
            StartCoroutine(WaitAndDisable(Success));
        }
        else
        {
            Failure.SetActive(true);
            StartCoroutine(WaitAndDisable(Failure));            
        }

    }

    IEnumerator WaitAndDisable(GameObject go)
    {
        yield return new WaitForSeconds(2.0f);
        go.SetActive(false);
        
    }
}
