using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    [FMODUnity.EventRef] public string SoundEvent = "";
    public EventInstance music;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        music = FMODUnity.RuntimeManager.CreateInstance(SoundEvent);
    }

    void Start()
    {
        music.start();
    }
}
