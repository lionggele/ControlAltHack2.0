using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("player").transform;
        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        CheckDistance();
    }
    
   /*
    void Update()
    {
        CheckDistance();
    }*/
    

    void CheckDistance()
    {
        if(Vector3.Distance(target.position,transform.position) <= chaseRadius && Vector3.Distance(target.position,transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.position,moveSpeed * Time.deltaTime);
            
            if(currentState == EnemyState.idle || currentState == EnemyState.walk ) //&& currentState == EnemyState.stagger
            {            
                transform.position = Vector3.MoveTowards(transform.position,target.position,moveSpeed * Time.deltaTime);
                //myRigidbody.MovePosition(temp);  
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp",true);   

            }
            else if(Vector3.Distance(target.position,transform.position) <= chaseRadius){
                anim.SetBool("wakeUp",false);
            }
            
            
        }   
    }

    
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("Xinput",setVector.x);
        anim.SetFloat("Yinput",setVector.y);
    }

    private void changeAim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            Debug.Log("X is greater");
            if(direction.x >0)
            {
                SetAnimFloat(Vector2.right);
            }else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }

        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            Debug.Log("y is greater");
            if(direction.y >0)
            {
                SetAnimFloat(Vector2.up);
            }else if(direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;  
        }
    }
    
    
}