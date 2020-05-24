﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Test : MonoBehaviour
{
    [SerializeField] AudioSource theAudio;

    [SerializeField] private AudioClip[] clip;


    private void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        int _temp = Random.Range(0, 4);

        theAudio.clip = clip[_temp];
        theAudio.Play();
    }

}
   
   
