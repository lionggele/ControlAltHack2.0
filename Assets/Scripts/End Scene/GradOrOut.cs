using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class GradOrOut : MonoBehaviourPunCallbacks
{
    public Text usernameTextW;
    public Text scoreTextW;
    public Text usernameTextL;
    public Text scoreTextL;
    public Text bestScoreText;
    public GameObject Win;
    public GameObject Lose;

    Player player;
    Hashtable hash = new Hashtable();

    int i=0;
    int low1,high1,low2,high2;
    int lowest,middle1,middle2,highest;
    int a,b,c,d;
    int LocalScore,Scores,BestScore;
    
    void Start(){

        foreach(Player player in PhotonNetwork.PlayerList){
    
            if(player.CustomProperties.TryGetValue("scores", out object scores)){
                    
                Scores = int.Parse(scores.ToString());
                    
                i++;
                if(i==1){
                    a = Scores;
                }else if(i==2){
                    b = Scores;
                }else if(i==3){
                    c = Scores;
                }else if(i==4){
                    d = Scores;
                }     
                    
            }
            

        }

        if(PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("scores", out object localscore)){
            usernameTextW.text = PhotonNetwork.NickName;
            scoreTextW.text = localscore.ToString();
            usernameTextL.text = PhotonNetwork.NickName;
            scoreTextL.text = localscore.ToString();
            LocalScore = int.Parse(localscore.ToString());
        }
        
        BestScore = SortLargestScore(a,b,c,d);

        if(LocalScore == BestScore){
            Win.SetActive(true);
        }else{
            bestScoreText.text = BestScore.ToString();
            Lose.SetActive(true);
        }
    }

    int SortLargestScore(int a, int b, int c, int d){
        if(a < b){
            low1 = a;
            high1 = b;
        }else{ 
            low1 = b;
            high1 = a;
        }

        if(c < d){
            low2 = c;
            high2 = d;
        }else{
            low2 = d;
            high2 = c;
        }

        if(low1 < low2){
            lowest = low1;
            middle1 = low2;
        }else{
            lowest = low2;
            middle1 = low1;
        }

        if (high1 > high2){
            highest = high1;
            middle2 = high2;
        }else{
            highest = high2;
            middle2 = high1;
        }

        return highest;
    }

    public void DisconnectPlayer(){
        hash.Add("scores", null);
        hash.Add("confirm",null);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom(){
        SceneManager.LoadScene("Lobby");
        base.OnLeftRoom();
    }

}


