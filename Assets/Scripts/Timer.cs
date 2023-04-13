using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    private bool stopped;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (!stopped) {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString("00");
            string seconds = (t % 60).ToString("00");
            string milliseconds = ((t * 1000) % 1000).ToString("000");

            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    public void StopTimer()
    {
        stopped = true;
        float elapsed = Time.time - startTime;
        string minutes = Mathf.Floor(elapsed / 60).ToString("00");
        string seconds = Mathf.Floor(elapsed % 60).ToString("00");
        string milliseconds = Mathf.Floor((elapsed - Mathf.Floor(elapsed)) * 1000).ToString("000");
        string timerFormatted = string.Format("{0}:{1}:{2}", minutes, seconds, milliseconds);
        Debug.Log("Elapsed time: " + timerFormatted);
    }

}
