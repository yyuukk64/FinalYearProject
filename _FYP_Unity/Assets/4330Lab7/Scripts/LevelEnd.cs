using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] string levelToLoad;
    [SerializeField] string levelToUnlock;
    [SerializeField] float waitToLoad;
    public GameObject player;
    public LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("WaitToLoadCo");
        }
    }

    public IEnumerator WaitToLoadCo()
    {
        player.SetActive(false);

        levelManager.levelMusic.Stop();
        levelManager.gameOverMusic.Play();

        levelManager.SavePlayerData();
        PlayerPrefs.SetInt(levelToUnlock, 1);

        yield return new WaitForSeconds(waitToLoad);

        SceneManager.LoadScene(levelToLoad);
    }
}
