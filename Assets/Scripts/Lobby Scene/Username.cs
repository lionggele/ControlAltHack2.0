using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Username : MonoBehaviour
{
    public InputField usernameInput;
    public GameObject UsernamePage;
    public Text myUsername;

    void Start(){
        if(PlayerPrefs.GetString("Username") == "" || PlayerPrefs.GetString("Username") == null){
            UsernamePage.SetActive(true);
;        }else{
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");

            myUsername.text = PlayerPrefs.GetString("Username");

            UsernamePage.SetActive(false);
        }
    }

    public void SaveUsername(){
        PhotonNetwork.NickName = usernameInput.text;

        PlayerPrefs.SetString("Username", usernameInput.text);

        myUsername.text = usernameInput.text;

        UsernamePage.SetActive(false);
    }
}
