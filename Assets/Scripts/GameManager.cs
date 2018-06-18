using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject platformSpawner;
    public static GameManager instance;

    public bool GameOver;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
        // Use this for initialization
        void Start()
        {
        GameOver = false;
        PlayerPrefs.SetInt("Diamond", 0);
        PlayerPrefs.SetInt("score2", 0);

        }

        // Update is called once per frame
        void Update()
        {

        }

    public void startGame()
    {
        UIManager.instance.gameStart();
        ScoreManager.instance.startScore();
        platformSpawner.GetComponent<PlatformSpawner>().StartSpawningPlatform();


    }

    public void gameOver(){
        UnityAdManager.instance.ShowAd();
        ScoreManager.instance.stopScore();
        UIManager.instance.gameOver();
        GameOver = true;
    }
    }

