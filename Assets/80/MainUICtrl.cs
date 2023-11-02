using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainUICtrl : MonoBehaviour
{
    public bool isPlaying;

    public TMP_Text scoreText;
    public TMP_Text timeText;
    public GameObject GameOverPanel;


    int score = 0;
    float gametime;
    [HideInInspector]
    public int PelletCount;

    private static MainUICtrl instance;

    public static MainUICtrl Instance
    {
         get { return instance; }
    }
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        Time.timeScale = 0;
    }

    float time;
    private void Update()
    {
        if (!isPlaying)
        {
            return;
        }
        
        if (daojishi)
        {
            if (Time.realtimeSinceStartup - time >= 3)
            {
                LoadScene();
            } 
        }
        GameTimer();
    }


    public void Score(int s)
    {
        score += s;
        PelletCount--;
        if (!isPlaying)
        {
            return;
        }
        scoreText.text = "Score:"+ score;
       
    }

    void Victory()
    {
        if (PelletCount == 0)
        {
            CurrentScore();
            Time.timeScale = 0;
            time = Time.realtimeSinceStartup;
            GameOverPanel.SetActive(true);
            daojishi = true;
        }
    }




    
    public void GameTimer()
    {
        gametime += Time.deltaTime;
        int minutes = (int)(gametime / 60);
        int seconds = (int)(gametime % 60);
        int fraction = (int)((gametime * 100) % 100);
        timeText.text = "Game Timer: "+ string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }



    bool daojishi;
    void LoadScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    
    void CurrentScore()
    {
        
        if (PlayerPrefs.HasKey("high score"))
        {
            
            if (PlayerPrefs.GetInt("high score")> score)
            {
                
                return;
                
            }else if (PlayerPrefs.GetInt("high score") == score)
            {
                
                if (PlayerPrefs.GetFloat("high score :"+ score) < gametime)
                {
                    
                    return;
                }
            }

        }

        PlayerPrefs.SetInt("high score", score);
        PlayerPrefs.SetFloat("high score :" + score, gametime);

    }
}
