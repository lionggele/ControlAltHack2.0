using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float m_moveSpeed = 3f;
    private Animator animator;
    Vector2 m_moveInput = Vector2.zero;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        m_rb.velocity = m_moveInput * m_moveSpeed;
    }

    void OnMove(InputValue value)
    {
        m_moveInput = value.Get<Vector2>();

            animator.SetFloat("Xinput", m_moveInput.x);
            animator.SetFloat("Yinput", m_moveInput.y);
        
    }

}
 

    /*
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

 
        if (flag == 3)
        {
            Destroy(door);
        }
        */
       

    
    /*

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("hit");
        }
        
        if (collision.gameObject.tag == "Flag")
        {
            //flag++;
            //flagAmount.text = "Flag " + flag;
            Destroy(collision.gameObject);
        }
        /*
        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("hit enemy ");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

   
        if (collision.gameObject.tag == "Princess" || flag == 4)
        {
            Escaped.text = "ESCAPED";
        }
        */



    /*
    public int flag= 0;
    public float speed = 5.0f;

    public Text flagAmount;
    public Text Escaped;
    public GameObject door;
    */
    // Start is called before the first frame update