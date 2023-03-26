 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float m_moveSpeed = 2f;
    private Animator animator;
    Vector2 m_moveInput;
    Rigidbody2D m_rb;

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
 
