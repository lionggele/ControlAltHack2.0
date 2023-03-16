using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card> ();
    public int thisId;

    public int id;
    public static int diceNum;
    public string cardName;
    public string majorName;

    void Start(){
        diceNum = 0;
        thisCard [0] = CardDatabase.cardList[thisId];
    }

    void Update(){

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        majorName = thisCard[0].majorName;

        if(diceNum != 0){
            if (id == 1 && (diceNum == 1 || diceNum == 2)){
                CharacterAssign.majorName = majorName;
            }else if (id == 2 && (diceNum == 3 || diceNum == 4)){
                CharacterAssign.majorName = majorName;
            }else if (id == 3 && (diceNum == 5 || diceNum == 6)){
                CharacterAssign.majorName = majorName;
            }else{
                gameObject.SetActive(false);
            }
        }

    }
}
