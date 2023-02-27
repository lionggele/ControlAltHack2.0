using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PlayerPerms : MonoBehaviour
{
    public GameObject startButton;
    public GameObject leaveButton;
    public GameObject WaitingLobbyPage;

    void Start(){

        if(PhotonNetwork.IsMasterClient == true){
            startButton.SetActive(true);
        }else{
            startButton.SetActive(false);
        }
    }

    public void DisconnectPlayer(){
        StartCoroutine(DisconnectAndActive());
    }

    IEnumerator DisconnectAndActive(){
        PhotonNetwork.LeaveRoom();
        while(PhotonNetwork.InRoom)
            yield return null;
        SceneManager.LoadScene("Lobby");
    }

    public void StartGame(){
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel("Random Character Scene");
        
    }

}
