using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 3f;
    [SerializeField]
    private string sceneNameToLoad;

    public static int confirm;
    private float timeElapsed;

    private void Update(){
        if (confirm != 0){
        timeElapsed += Time.deltaTime;
        }

        if (timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

}
