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

    }

    public string GetUserInput()
    {
        return userInput;
    }

}
