using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;


    // References
    public Player1 Player_0;
    //public weapon weapon...
    public FloatingTextManager floatingTextManager;

    //Logic
    public int pesos;
    public int experience;

    private void Awake()
    {
        floatingTextManager = FindObjectOfType<FloatingTextManager>();
        if(GameManager.instance != null){
            Destroy(gameObject);
            return;
       }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }


    //Floating Text
    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        if (floatingTextManager != null)
        {
            
            floatingTextManager.Show(message, fontSize, color, position, motion, duration);
            
        }
        else
        {
            Debug.Log("One or more parameters are null.");
        }
        
    }
    //Save state
    public void SaveState()
    {
        Debug.Log("SaveState");
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;
         
        Debug.Log("LoadState");
    }
}


        
