using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneMgr : MonoBehaviour
{
    public TMP_Text Text_fen;
    public TMP_Text Text_time;

    private void Start()
    {
        GetZuigaofen();
    }


    void GetZuigaofen()
    {
        if (PlayerPrefs.HasKey("high score"))
        {
            Text_fen.text = "high score :" + PlayerPrefs.GetInt("high score");
            Text_time.text = "time :" + TimeFormat( PlayerPrefs.GetFloat(Text_fen.text));
        }
        else
        {
            Text_time.text = "time :00:00:00";
            Text_fen.text = "high score :0";
        }
        
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    string TimeFormat(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int fraction = (int)((time * 100) % 100);
        return  string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

}
