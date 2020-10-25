using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Animation blendPostEffect;
    public AudioManager am;

    public string nextLevel;
    private void OnTriggerEnter(Collider other)
    {
        if(blendPostEffect) blendPostEffect.Play();
        if(am)am.playEndGame();
    }

    private void nextLaevel()
    {

    }
    
}
