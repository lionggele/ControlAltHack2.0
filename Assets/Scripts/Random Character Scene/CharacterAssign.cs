using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAssign : MonoBehaviour
{
   
    public static string majorName;
    public string major;
    public string MajorName;

    void Update()
    {
        major = majorName;
        SetMajor(MajorName, major);
        SceneLoader.ConfirmedMajor = majorName;
    }

    public void SetMajor(string MajorName, string major){
        PlayerPrefs.SetString(MajorName, major);
    }

}
