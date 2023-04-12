using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu]
public class FloatValue : ScriptableObject // , ISerializationCallBackReceiver // outside the scene // multiple scene
{
    public float initialValue;
    /*
    [HideInInspector]
    public float RuntimeValue;

    public void OnAfterDeserialize(){
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}
    */
    
}
 