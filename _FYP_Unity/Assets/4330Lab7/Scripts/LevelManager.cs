using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public PlayerController playerController;
    public float waitToRespawn;

    public GameObject deathExplosion;

    [SerializeField] private int coinCount;
    [SerializeField] private int diamondCount;
    public Text coinText, diamondText;
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;
    [SerializeField] int health, maxHealth = 6;
    private bool respawning = false;
    public ResetOnRespawn[] objectsToReset;

    public Text livesText;
    public int startingLives, currentLives;

    public GameObject gameOverScreen;
    public int bonusLifeCoinValue;
    public AudioSource coinSound;
    public AudioSource levelMusic, gameOverMusic;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        coinText.text = "Coins: " + coinCount;
        if (PlayerPrefs.HasKey("DiamondCount"))
        {
            coinCount = PlayerPrefs.GetInt("DiamondCount");
        }
        diamondText.text = "Diamond: " + diamondCount;
        health = maxHealth;
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            currentLives = startingLives;
        }
        livesText.text = "Lives x " + currentLives;
        Time.timeScale = 1; 
    }

    private void Update()
    {
        if (health <= 0)
        {
            RespawnPlayer();
        }

        if (coinCount >= bonusLifeCoinValue)
        {
            currentLives += 1;
            coinCount -= bonusLifeCoinValue;
            livesText.text = "Lives x " + currentLives;
            coinText.text = "Coin: " + coinCount;
        }
    }

    public void RespawnPlayer()
    {
        if (!respawning)
        {
            if (currentLives > 1)
            {
                currentLives -= 1;
                respawning = true;
                StartCoroutine("RespawnPlayerCo");
            }
            else if (currentLives == 1)
            {
                currentLives -= 1;
                playerController.gameObject.SetActive(false);
                gameOverScreen.SetActive(true);
                levelMusic.Stop();
                gameOverMusic.Play();
                Time.timeScale = 0;
            }
            livesText.text = "Lives " + currentLives;
        }
    }

    public IEnumerator RespawnPlayerCo()
    {
        playerController.gameObject.SetActive(false);
        Instantiate(deathExplosion, playerController.transform.position, playerController.transform.rotation);
        yield return new WaitForSeconds(waitToRespawn);

        respawning = false;
        health = maxHealth;
        UpdateHeartUI();

        playerController.transform.position = playerController.respawnPosition;
        playerController.gameObject.SetActive(true);

        for (int i = 0; i<objectsToReset.Length; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
    }

    public void AddCoin(int coinToAdd)
    {
        coinCount += coinToAdd;
        coinText.text = "Coins: " + coinCount;
        coinSound.Play();
    }

    public void AddDiamond(int diamondToAdd)
    {
        diamondCount += diamondToAdd;
        diamondText.text = "Diamonds: " + diamondCount;
    }

    public void AddLives(int livesToAdd)
    {
        currentLives += livesToAdd;
        livesText.text = "Lives x " + currentLives;
        coinSound.Play();
    }

    public void DamagePlayer (int damageToTake)
    {
        health -= damageToTake;
        UpdateHeartUI();
        playerController.myAnim.SetTrigger("HurtFlash");
        playerController.hurtSound.Play();
    }

    private void UpdateHeartUI()
    {
        switch (health)
        {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;
        }
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.SetInt("DiamondCount", diamondCount);
        PlayerPrefs.SetInt("PlayerLives", currentLives);
    }

    public void ResetPlayerData()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("DiamondCount", 0);
        PlayerPrefs.SetInt("PlayerLives", startingLives);
    }
}


