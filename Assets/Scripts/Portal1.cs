using UnityEngine;

public class Portal1 : Collidable
{
    public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player_0"){
            // GameManager.instance.SaveState();
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
