using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgr : MonoBehaviour
{
    private static AudioMgr instance;

    public static AudioMgr Instance {  get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    public AudioSource aud;
    public AudioClip coin;


    public void EatingCoins()
    {
        aud.clip = coin;
        aud.Play();
    }

}
