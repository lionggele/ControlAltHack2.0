using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{   
    public InputField createInput;
    public InputField joinInput;
    public GameObject WaitingLobbyPage;
    [SerializeField] Transform playersContent;
    [SerializeField] GameObject PlayersPrefab;

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
        
        Player[] players = PhotonNetwork.PlayerList;

        for(int i = 0 ; i < players.Count(); i++){
            Instantiate(PlayersPrefab,playersContent).GetComponent<Players>().SetUp(players[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log(newPlayer.NickName + " has joined the room");
        Instantiate(PlayersPrefab,playersContent).GetComponent<Players>().SetUp(newPlayer);
    }

    public override void  OnPlayerLeftRoom(Player otherPlayer){
        Debug.Log(otherPlayer.NickName + " has left the room");
    }
}
