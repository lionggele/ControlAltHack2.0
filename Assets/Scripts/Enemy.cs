using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public FloatValue maxHealth;
    public float health;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Awake()
    {
        health = maxHealth.initialValue;   
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            //animator.SetBool("death",true);
            this.gameObject.SetActive(false);
        }
    }    

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage) 
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(KnockCo(myRigidbody,knockTime));
            TakeDamage(damage);
            Debug.Log(health);
        }
    }
    
    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
    {
        if(myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
       
    public float GetHealth()
    {
        return health;
    }  

}
