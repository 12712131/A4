using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundStartCtrl : MonoBehaviour
{
    public TMP_Text text;
    int index = 3;
    float time;
    private void Start()
    {
        Time.timeScale = 0;
        text.text = index.ToString();
        time = Time.realtimeSinceStartup;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - time >= 1)
        {
            time = Time.realtimeSinceStartup;
            Show();
        }
    }

    void Show()
    {
        index--;
        if (index == 0)
        {
            text.text = "GO";
            return;
        }else if (index == -1)
        {
            MainUICtrl.Instance.isPlaying = true;
            Time.timeScale = 1;
            Destroy(gameObject);
        }
        text.text = index.ToString();
    }

}
