using UnityEngine;

public class Porta : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        
        if(coll.name == "Player_0 "){
            Debug.Log("player");
                //Teleport the player
            if(sceneNames.Length > 0) {       
                string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
            }
            // Stop the timer
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null) {
                timer.StopTimer();
            }
        }
    }
}