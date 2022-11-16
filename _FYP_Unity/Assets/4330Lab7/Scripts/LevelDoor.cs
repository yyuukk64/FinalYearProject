using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    [SerializeField] string levelToLoad;

    public bool unlocked;

    [SerializeField] Sprite doorBottomOpen, doorTopOpen, doorBottomClosed, doorTopClosed;
    [SerializeField] SpriteRenderer doorBottom, doorTop;

    private void Start()
    {
        PlayerPrefs.SetInt("Level1", 1);

        if (PlayerPrefs.GetInt(levelToLoad) == 1)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }

        if (unlocked)
        {
            doorTop.sprite = doorTopOpen;
            doorBottom.sprite = doorBottomOpen;
        }
        else
        {
            doorTop.sprite = doorTopClosed;
            doorBottom.sprite = doorBottomClosed;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && unlocked)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
