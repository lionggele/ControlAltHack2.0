using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer(){
        if(isCorrect){
            Debug.Log("Correct Answer");
            quizManager.RPC_GetScore();
            quizManager.correct();
        }else{
            Debug.Log("Wrong Answer");
            quizManager.correct();
        }
    }
}
