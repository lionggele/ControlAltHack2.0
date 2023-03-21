using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChangeUsernamePage : MonoBehaviour
{
    public GameObject changeUsernamePage;
    public InputField usernameInput;
    public Text myUsername;

    public void openChangeUsernamePage(){
        changeUsernamePage.SetActive(true);
    }

    public void SaveUsername(){
        string check = usernameInput.text;
        if(!string.IsNullOrWhiteSpace(check)){
            PhotonNetwork.NickName = usernameInput.text;

            PlayerPrefs.SetString("Username", usernameInput.text);

            myUsername.text = usernameInput.text;

            changeUsernamePage.SetActive(false);
        }else{
            Debug.LogError("Username can't be empty");
        }
    }
}