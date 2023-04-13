using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization;



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
 