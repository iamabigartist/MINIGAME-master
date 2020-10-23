using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public Animation blendPostEffect;
    public AudioManager am;
    private void OnTriggerEnter(Collider other)
    {
        blendPostEffect.Play();
        am.playEndGame();
    }
    
    
}
