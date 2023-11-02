using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCtrl : MonoBehaviour
{
    [HideInInspector]
    public bool Playing;
    public ParticleSystem ps;
    public float Interval;
    float time;

    public AudioSource aud;
    public AudioClip clip;


    private void Start()
    {
        aud.clip = clip;    
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (Playing && time > Interval)
        {
            Play();
            Playing = false;
        }
    }

    void Play()
    {
        ps.Play();
        aud.Play(); 
        time = 0;
    }


}
