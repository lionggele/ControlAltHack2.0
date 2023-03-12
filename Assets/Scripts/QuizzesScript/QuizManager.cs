using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int questionsAnswered = 0;
    public int cheat;
    public string MajorName;
    int scores;

    public Text QuestionTxt;

    [SerializeField]
    private string sceneNameToLoad;

    private void Start(){
        generateQuestion();
    }


    public void correct(){
        QnA.RemoveAt(currentQuestion);
        if(questionsAnswered < 2){
            questionsAnswered += 1;
            generateQuestion();
        }else if(questionsAnswered == 2){
            SceneManager.LoadScene(sceneNameToLoad);
        }
        
    }

    void SetAnswers(){
        for (int i = 0; i < options.Length; i++){
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            options[i].transform.GetChild(0).GetComponent<Text>().color = Color.white;

            if(QnA[currentQuestion].CorrectAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
            }

            if(i==3 && QnA[currentQuestion].QuestionType == GetString(MajorName)){
                cheat = Random.Range(1, 5);
                
                do{
                    cheat = Random.Range(1, 5);
                }
                while(cheat == QnA[currentQuestion].CorrectAnswer);

                options[cheat-1].transform.GetChild(0).GetComponent<Text>().color = Color.red;
                options[cheat-1].transform.GetChild(0).GetComponent<Text>().text = "WRONG ANSWER >;D";        
            }
            
        }    
    } 

    void generateQuestion(){
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
    }


    [PunRPC]
    public void RPC_GetScore(){
        scores++;

        Hashtable hash = new Hashtable();
        hash.Add("scores", scores);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public string GetString(string MajorName){
        return PlayerPrefs.GetString(MajorName);
    }
}
