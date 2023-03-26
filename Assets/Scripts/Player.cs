 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState{
    walk,
    attack,
    interact,
}
public class Player : MonoBehaviour
{
    public PlayerState currentState;
    public float m_moveSpeed = 2f;
    private Animator animator;
    Vector2 m_moveInput;
    Rigidbody2D m_rb;
    public KeyCode toggleKey = KeyCode.Space;

    void Start()
    {
        //gameObject.tag="player";
        m_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
         //m_rb.velocity = m_moveInput * m_moveSpeed;
        m_rb.MovePosition(m_rb.position + m_moveInput * m_moveSpeed * Time.fixedDeltaTime);
        

        
        if (m_moveInput != Vector2.zero){

            m_rb.MovePosition(m_rb.position + m_moveInput * m_moveSpeed * Time.fixedDeltaTime);
            animator.SetBool("isWalking",true);
        }
        else{
            animator.SetBool("isWalking",false);
        }    
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            animator.SetBool("attacking",true);
        
        }
        else
        {
            animator.SetBool("attacking",false);
        }        
    }

 

    void OnMove(InputValue value)
    {
        m_moveInput = value.Get<Vector2>();
        if (m_moveInput != Vector2.zero)
        {
            animator.SetFloat("Xinput", m_moveInput.x);
            animator.SetFloat("Yinput", m_moveInput.y);            
        }
        
    }


}
        /*
        if(Input.GetKeyDown(toggleKey))//&& currentState != PlayerState.attack)
        {
            Debug.Log(Input.GetButtonDown("attack"));
            //StartCoroutine(AttackCo());
            animator.SetBool("attacking",true);
            //currentState = PlayerState.attack;

        }
        else 
        {
            //OnMove();
            //Debug.Log("walk");
            
            animator.SetBool("attacking",false);
            
        }
        */
   /*

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking",true);
        //currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking",false);
        yield return new WaitForSeconds(.1f);
        //currentState = PlayerState.walk;
    }
    */
 
