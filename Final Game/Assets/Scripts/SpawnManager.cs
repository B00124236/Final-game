using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject Trump;
    public GameObject Coronavirus;
    public GameObject Powerup;
    public GameObject Title;
    public TextMeshProUGUI scoreAmount;
    public TextMeshProUGUI gameOver;
    public bool activeGame;
    public Button restartButton;

    private int score;

    private float zTrumpSpawn = 15.0f;
    private float xSpawnRange = 10.0f;
    private float zPowerupSpawn = 15.0f;
    private float zCoronavirusSpawn = 15.0f;
    private float ySpawn = 0.75f;

    private float trumpSpawnTime = 5.0f;
    private float coronavirusSpawnTime = 3.0f;
    private float powerupSpawnTime = 5.0f;
    private float startDelay = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
        InvokeRepeating("SpawnTrump", startDelay, trumpSpawnTime);
        InvokeRepeating("SpawnCoronavirus", startDelay, coronavirusSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTrump()
    {
        if (activeGame) {
            {
                float randomX = Random.Range(-xSpawnRange, xSpawnRange);

                Vector3 spawnPos = new Vector3(randomX, ySpawn, zTrumpSpawn);

                Instantiate(Trump, spawnPos, Trump.gameObject.transform.rotation);
            }
        }
    }

    void SpawnCoronavirus()
    {
        if (activeGame) {
            {
                float randomX = Random.Range(-xSpawnRange, xSpawnRange);

                Vector3 spawnPos = new Vector3(randomX, ySpawn, zCoronavirusSpawn);

                Instantiate(Coronavirus, spawnPos, Coronavirus.gameObject.transform.rotation);
            }
        }
    }

    void SpawnPowerup()
    {
        if (activeGame) {
            {
                float randomX = Random.Range(-xSpawnRange, xSpawnRange);

                Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupSpawn);

                Instantiate(Powerup, spawnPos, Powerup.gameObject.transform.rotation);
            }
        }

    }

    public void AddtoScore(int scoreUpdate)
    {
        score += scoreUpdate;
        scoreAmount.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);

        gameOver.gameObject.SetActive(true);

        activeGame = false;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(int levelofDifficulty)
    {
        activeGame = true;
        score = 0;
        coronavirusSpawnTime /= levelofDifficulty;
        AddtoScore(0);

        Title.gameObject.SetActive(false);
    }
}
