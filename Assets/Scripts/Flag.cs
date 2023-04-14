using UnityEngine;  
using UnityEngine.UI;

public class Flag : MonoBehaviour
{
    private int flagCount;
    private int flag;
    public Text dialogText;
    public GameObject door;

    private void Start()
    { 
        door.SetActive(true);
        UpdateFlagCountText();
        flagCount = 0;
        flag = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            flagCount++;
            flag = flag + flagCount;
            UpdateFlagCountText();
            CheckFlagCount();
            Destroy(gameObject);
        }
    }

    private void UpdateFlagCountText()
    {
        dialogText.text = "Flags collected:";
    }

    private void CheckFlagCount()
    {
        if (flagCount == 4)
        {
            door.SetActive(false);
        }
    }
}
