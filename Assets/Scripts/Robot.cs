using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    //private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;


    // Start is called before the first frame update
    void Start()
    {
        //myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position,transform.position) <= chaseRadius && Vector3.Distance(target.position,transform.position) > attackRadius)
        {
            //Vector3 temp = 
            transform.position = Vector3.MoveTowards(transform.position,target.position,moveSpeed * Time.deltaTime);
            //myRigidbody.MovePosition(temp);  
        }
        


    }
}
