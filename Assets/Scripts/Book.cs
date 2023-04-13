using UnityEngine;

public class Book : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite showSprite;
    public bool playerInRange;
    public float range = 2.0f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the desired object
        if (collision.gameObject.CompareTag("player"))
        {
            // Show the sprite
            spriteRenderer.sprite = showSprite;
        }
    }
    
        void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("player")){
            playerInRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("player")){
            playerInRange = false;            
        }
    }
}
