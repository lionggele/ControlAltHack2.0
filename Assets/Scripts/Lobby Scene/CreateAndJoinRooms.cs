using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{   
    //public List<string> usernames = new List<string>();
    public InputField createInput;
    public InputField joinInput;
    public GameObject WaitingLobbyPage;

    public void CreateRoom(){
        if (createInput.text == "" || createInput.text == null){
            Debug.LogError("Room name can't be empty");
        }else{
            PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() {MaxPlayers = 4});
        }
        
    }

    public void JoinRoom(){
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom(){    
        Debug.Log(PhotonNetwork.NickName + " has made the room");
        WaitingLobbyPage.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log(newPlayer.NickName + " has joined the room");
        PlayerPerms.usernames.Add(newPlayer.NickName);
    }

    public override void  OnPlayerLeftRoom(Player otherPlayer){
        Debug.Log(otherPlayer.NickName + " has left the room");
        PlayerPerms.usernames.Remove(otherPlayer.NickName);
    }
}
