using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputExample : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button submitButton;
    public GameObject userpage;
    public string userInput = "";

    void Start()
    {
        // Add listener to the button so that it calls SubmitInput() function when clicked
        submitButton.onClick.AddListener(SubmitInput);
    }

    void SubmitInput()
    {
        // Save the user input in the userInput variable
        userInput = inputField.text;

        // Clear the input field after submission
        Debug.Log(inputField.text);
        //inputField.SetActive(false);
        //userpage.SetActive(false);

        //https://www.youtube.com/watch?v=4n6RT805rCc&t=275s&ab_channel=CodeMonkey

    }
}
