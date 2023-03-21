using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class Password : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button submitButton;
    public GameObject userpage;
    public string userInput = "";

    void Start()
    {
        // Add listener to the button so that it calls SubmitInput() function when clicked
        submitButton.onClick.AddListener(SubmitInput);
        InputSystem.DisableDevice(Keyboard.current);
        userpage.SetActive(true);
        
        
    }

    void SubmitInput()
    {
        // Save the user input in the userInput variable
        userInput = inputField.text;

        
        Debug.Log(inputField.text);
        InputSystem.EnableDevice(Keyboard.current);
    
        userpage.SetActive(false);
        //submitButton.SetActive(false);
        //inputField.SetActive(false);
        //userpage.SetActive(false);

        //https://www.youtube.com/watch?v=4n6RT805rCc&t=275s&ab_channel=CodeMonkey

    }
}
