using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int flag= 0;
    public float speed = 5.0f;

    public Text flagAmount;
    public Text Escaped;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            Debug.Log("hit");
        }
        
        if (collision.gameObject.tag == "Flag")
        {
            flag++;
            flagAmount.text = "Flag " + flag;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Enemies")
        {
            Debug.Log("hit enemy ");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

   
        if (collision.gameObject.tag == "Princess" || flag == 4)
        {
            Escaped.text = "ESCAPED";
        }



    }
}