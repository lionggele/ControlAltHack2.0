using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Players : MonoBehaviour
{
    public void OnPlayerEnteredRoom(Player newPlayer){
        Debug.Log(newPlayer.NickName + " has joined the room");
        PlayerPerms.usernames.Add(PhotonNetwork.NickName);
    }

    void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.Log(otherPlayer.NickName + " has joined the room");
        PlayerPerms.usernames.Remove(otherPlayer.NickName);
    }
}
