using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    public Vector2 maxPosition;
    public Vector2 minPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate(){
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookAt.position.x){
                delta.x = deltaX - boundX;
            }
            else{
                delta.x = deltaX + boundX;
            }
        }


        // this is to heck if we're inside the bounds on the Y axis 
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY)
        {
            if(transform.position.y < lookAt.position.y){
                delta.y = deltaY - boundY;
            }
            else{
                delta.y = deltaY + boundY;
            }
        }
        transform.position += new Vector3(delta.x,delta.y,0);
    
        if(transform.position != transform.position){
            Vector3 targetPosition = new Vector3(delta.x,delta.y,0);
            targetPosition.x = Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,minPosition.y,maxPosition.y);


        }

        
    
    }


}
