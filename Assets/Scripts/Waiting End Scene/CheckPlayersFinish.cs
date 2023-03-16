using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CheckPlayersFinish : MonoBehaviourPunCallbacks
{
    int confirm = 1;
    int i;
    public GameObject waitingForOthers;
    
    Player player;

    void Start(){
        Hashtable hash = new Hashtable();  
        hash.Add("confirm", confirm);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    void Update(){
        i=0;
        foreach(Player player in PhotonNetwork.PlayerList){

            if(player.CustomProperties.TryGetValue("confirm", out object eachConfirm)){
                int ConfirmationForAll = int.Parse(eachConfirm.ToString());
                if(ConfirmationForAll == 1){
                    i++;
                }
            }
            
        }

        if(i == PhotonNetwork.CurrentRoom.PlayerCount){
            PhotonNetwork.AutomaticallySyncScene = true;
            SceneManager.LoadScene("End Scene");
        }
    }
}
