using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public float blend = 0.01f;

    public AudioClip[] bgm;
    private int i=0;
    public AudioClip endGame;
    public AudioClip inAir;
    public AudioClip run;

    public MovingSphere player;

    private AudioSource audioSource;
    private AudioSource audioSource2;

    private bool play = true;
    private bool lastGround;
    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        
        player = GetComponentInParent<MovingSphere>();
        play = (bgm.Length>0 && endGame && inAir);
        
        audioSource.clip = bgm[0];
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 1;

        audioSource2.clip = inAir;
        audioSource2.loop = true;
        audioSource2.playOnAwake = true;

        audioSource2.volume = 0;
    }

    private void Update()
    {
        if (!play) return;
        
        if (player.OnGround ^ lastGround )
        {
            i++;
            if (i >= bgm.Length)
            {
                i = 0;
            }
            
            
        }
        if (player.OnGround)
        {

            audioSource.clip = bgm[i];
            audioSource.volume += blend;
            audioSource2.volume -= blend;

        }
        else
        {
            audioSource2.volume += blend;
            audioSource.volume -= blend;
        }


        if (!audioSource.isPlaying || !audioSource2.isPlaying)
        {
            audioSource.PlayDelayed(1.0f);
            audioSource2.PlayDelayed(1.0f);
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
