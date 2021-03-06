﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager3D : MonoBehaviour
{
    private static AudioManager3D instance;
    public static AudioManager3D Instance
    {
        get
        {
            return instance;
        }
    }

    [FMODUnity.EventRef] public string SoundEvent = "";
    public EventInstance music;
    bool playing = false;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    void Update()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master") && !playing)
        {
            playing = true;
            music = FMODUnity.RuntimeManager.CreateInstance(SoundEvent);
            music.start();
        }
        
    }
}
