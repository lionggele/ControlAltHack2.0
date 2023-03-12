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

            if(QnA[currentQuestion].CorrectAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
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
}
