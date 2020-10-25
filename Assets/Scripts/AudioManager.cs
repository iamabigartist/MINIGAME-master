using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] bgm;
    private int i=0;
    public AudioClip endGame;
    public AudioClip inAir;
    public AudioClip run;

    public MovingSphere player;
    
    AudioSource audioSource;

    private bool play = true;
    private bool lastGround;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponentInParent<MovingSphere>();
        play = (bgm.Length>0 && endGame && inAir);
        
        audioSource.clip = bgm[0];
        audioSource.loop = true;
        audioSource.playOnAwake = true;
    }

    private void Update()
    {
        if (!play) return;
        
        
        
        if (player.OnGround ^ lastGround )
        {
            audioSource.Stop();
            audioSource.clip = inAir;
            if (player.OnGround)
            {
                i++;
                if (i>=bgm.Length)
                {
                    i = 0;
                }
                audioSource.clip = bgm[i];
            }
            audioSource.PlayDelayed(0.1f);
        }

        if (!audioSource.isPlaying)
        {
            audioSource.PlayDelayed(1.0f);
        }
        

        lastGround = player.OnGround;
    }

    public void  playEndGame()
    {
        audioSource.Stop();
        audioSource.clip = endGame;
        audioSource.PlayDelayed(0.2f);
    }
    
}
