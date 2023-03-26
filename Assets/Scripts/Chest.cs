using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int pesosAmount;
    protected override void OnCollect(){
        
        if(!collected){
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Debug.Log("Grant"+ pesosAmount +"pesos");
            GameManager.instance.ShowText("+" + pesosAmount +"pesos!",25,Color.yellow,transform.position,Vector3.up*100,3.0f);
        }
    }
}
