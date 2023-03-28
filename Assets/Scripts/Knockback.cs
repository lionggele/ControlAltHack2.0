using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;

    public EnemyState currentState;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("player"))
        {
            other.GetComponent<Pot>().Smash();
        }
        if(other.gameObject.CompareTag("enemy")|| other.gameObject.CompareTag("player") )
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);                   
                if(other.gameObject.CompareTag("enemy") )
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;                    
                    other.GetComponent<Enemy>().Knock(hit,knockTime,damage); //,damage
                }
                
                if(other.gameObject.CompareTag("player"))
                {
                    hit.GetComponent<Player1>().currentState = Player1State.stagger;
                    other.GetComponent<Player1>().Knock(knockTime);
                }
            }       
        }        
    }
}
