using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTriggerEvnet : MonoBehaviour
{
    public Pellet pellet;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("other =" + collision.name);
        if (collision.tag == "Player")
        {
            AudioMgr.Instance.EatingCoins();
            MainUICtrl.Instance.Score(pellet.score);
            Destroy(gameObject);
        }
    }
}
[System.Serializable]
public class Pellet
{
    public int score;
}