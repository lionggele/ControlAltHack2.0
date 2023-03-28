using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Player1State{
    walk,
    attack,
    interact,
    stagger,
    idle
}
public class Player1 : MonoBehaviour
{
    public Player1State currentState;
    public float m_moveSpeed = 2f;
    private Animator animator;
    Vector2 m_moveInput;
    Rigidbody2D m_rb;
    public KeyCode toggleKey = KeyCode.Space;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Xinput", 0);
        animator.SetFloat("Yinput", -1);
        currentState = Player1State.idle;
    }

    void FixedUpdate()
    {
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
        if (Input.GetKeyDown(toggleKey))//&& currentState != Player1State.attack && currentState != Player1State.stagger)
        {
            animator.SetBool("attacking",true);
            
        
        }
        else //if (currentState == Player1State.walk ||currentState == Player1State.idle)
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
    
    public void Knock(float knockTime)
    {
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo( float knockTime)
    {
        if(m_rb != null && currentState != Player1State.stagger)
        {
            yield return new WaitForSeconds(knockTime);
            m_rb.velocity = Vector2.zero;
            currentState = Player1State.idle;
            m_rb.velocity = Vector2.zero;        
        }
        
    }
}

 
