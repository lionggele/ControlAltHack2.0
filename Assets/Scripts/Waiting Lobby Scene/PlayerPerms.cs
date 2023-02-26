using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class PlayerPerms : MonoBehaviour
{
    public static List<string> usernames = new List<string>();
    public List<string> usernameshere = new List<string>();
    public Text Username, Username1, Username2, Username3;
    public GameObject startButton;

    void Start(){

        if(PhotonNetwork.IsMasterClient == true){
            startButton.SetActive(true);
        }else{
            startButton.SetActive(false);
        }
    }

    /*public override void OnPlayerEnteredRoom(Player newPlayer){
        usernames.Add(PhotonNetwork.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        usernames.Remove(PhotonNetwork.NickName);
    }

    void Update(){
        foreach (Player Player in PhotonNetwork.PlayerList) {
            usernames.Add (PhotonNetwork.NickName);
        }
    }*/

    void Update(){
        //Username.GetComponent<Text> ().text = (usernames[0]);
        usernameshere = usernames;
    }

    public void StartGame(){
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("Random Character Scene");
        
    }

}
