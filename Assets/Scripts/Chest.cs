using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount;
    public string chestTag;
    protected override void OnCollect(){
        
        if(!collected){
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Debug.Log("Grant"+ pesosAmount +"pesos");
            GameManager.instance.ShowText(pesosAmount +" Coins!",30,Color.yellow,transform.position,Vector3.up*100,4.0f);
        }
    }
}
