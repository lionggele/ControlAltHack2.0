using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;

public class MajorTypeShow : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public GameObject MT;
    public Text MajorType;
    public Text MajorTypeFull;
    
    string MajorName;

    void Start(){
        if(GetString(MajorName)=="CC"){
            MajorType.text = GetString(MajorName);
            MajorTypeFull.text = "Cloud Computing";
            MajorType.color = new Color(0f/255f,232f/255f,240f/255f);
            MajorTypeFull.color = new Color(0f/255f,232f/255f,240f/255f);
        }else if(GetString(MajorName)=="DM"){
            MajorType.text = GetString(MajorName);
            MajorTypeFull.text = "Data Management";
            MajorType.color = new Color(0f/255f,255f/255f,171f/255f);
            MajorTypeFull.color = new Color(0f/255f,255f/255f,171f/255f);
        }else if(GetString(MajorName)=="HK"){
            MajorType.text = GetString(MajorName);
            MajorTypeFull.text = "Hacking";
            MajorType.color = new Color(255f/255f,22f/255f,22f/255f);
            MajorTypeFull.color = new Color(255f/255f,22f/255f,22f/255f);
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData){
        MT.SetActive(true);
    }   

    public void OnPointerExit(PointerEventData eventData){
        MT.SetActive(false);
    }

    public string GetString(string MajorName){
        return PlayerPrefs.GetString(MajorName);
    }
}
