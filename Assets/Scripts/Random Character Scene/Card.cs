using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public string majorName;

    public Card(int Id, string CardName, string MajorName){
        id=Id;
        cardName=CardName;
        majorName=MajorName;
    }

}
