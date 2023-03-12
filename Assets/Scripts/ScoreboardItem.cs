using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class ScoreboardItem : MonoBehaviourPunCallbacks
{
    public Text usernameText;
    public Text scoreText;

    Player player;

    public void Initialize(Player player){
        this.player = player;
        usernameText.text = player.NickName;
        UpdateStats();
    }

    void UpdateStats(){
        if(player.CustomProperties.TryGetValue("scores", out object scores)){
            scoreText.text = scores.ToString();
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changeProps){
        if(targetPlayer == player){
            if(changeProps.ContainsKey("scores")){
                UpdateStats();
            }
        }
    }
}
