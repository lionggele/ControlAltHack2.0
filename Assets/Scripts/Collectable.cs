using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable 
{
    //Logic
    protected bool collected;

    protected override void OnCollide(Collider2D coll){
        //Debug.Log(coll.name);
        
        if(coll.name == "Player_0"){
            OnCollect();
        }   
    }

    protected virtual void OnCollect(){
        collected = true;
    }
}
