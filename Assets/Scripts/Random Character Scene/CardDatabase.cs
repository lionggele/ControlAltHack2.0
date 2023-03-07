using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();

    void Awake(){
        cardList.Add (new Card (0, "None", "None"));
        cardList.Add (new Card (1, "CharacterCLOUD", "CC"));
        cardList.Add (new Card (2, "CharacterDATA", "DM"));
        cardList.Add (new Card (3, "CharacterHACK", "HK"));
    }
}
