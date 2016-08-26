using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Done_GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float starWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;
    public static Done_GameController S;

    void Start()
    {

        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnWaves());
        if (S == null)
        {
            S = this;
        }
    }
    void Update()
    {

        if (restart)
        {
            //if(Input.GetButtonDown(KeyCode.R))
            if (UnityEngine.Input.GetButtonDown("R"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);﻿

            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(starWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                Input.GetKeyDown(KeyCode.R);
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;

    }
    public void GameOver()
    {
        while (!gameOver)
        {
            restartText.text = "Pres 'R' for Restart";
            restart = true;
        } gameOverText.text = "Game Over!";
        gameOver = true;

    }
}

