using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Image timer_linear_image;
    float time_remaining;
    public float max_time;

    [SerializeField]
    private string sceneNameToLoad;

    void Start(){
        time_remaining = max_time;
    }

    void Update(){
        if(time_remaining > 0){
            time_remaining -= Time.deltaTime;;
            timer_linear_image.fillAmount = time_remaining / max_time;
        }else{
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
