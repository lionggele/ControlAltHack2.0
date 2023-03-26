using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Collision work 
        boxCollider.OverlapCollider(filter,hits);
        for(int i =0; i < hits.Length; i++){
            if(hits[i]== null)
            {
                continue;
            }
            OnCollide(hits[i]);

            // The array is not cleaned up, so we do it ourself
            hits[i] = null;
        }

    }

    protected virtual void OnCollide(Collider2D coll){
        //Debug.Log(coll.name);
    }
}
