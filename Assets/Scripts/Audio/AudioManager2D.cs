using UnityEngine;
using System.Collections;
using FMOD.Studio;
using System.Collections.Generic;

public enum Sound { Bullet, EnemyHit, PlayerHit, Noise, Music }
public class AudioManager2D : MonoBehaviour
{
    private static AudioManager2D instance;

    public static AudioManager2D Instance
    {
        get
        {
            return instance;
        }
    }

    [FMODUnity.EventRef] public string BulletEvent = "";
    [FMODUnity.EventRef] public string PlayerHitEvent = "";
    [FMODUnity.EventRef] public string EnemyHitEvent = "";
    [FMODUnity.EventRef] public string NoiseEvent = "";
    [FMODUnity.EventRef] public string MusicEvent = "";
    private EventInstance bulletEvent;
    private EventInstance playerHitEvent;
    private EventInstance enemyHitEvent;
    private EventInstance noiseEvent;
    private EventInstance musicEvent;

    bool loaded = false;

    private Dictionary<Sound, EventInstance> sounds;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    void Update()
    {
        if (FMODUnity.RuntimeManager.HasBankLoaded("Master") && !loaded)
        {
            bulletEvent = FMODUnity.RuntimeManager.CreateInstance(BulletEvent);
            playerHitEvent = FMODUnity.RuntimeManager.CreateInstance(PlayerHitEvent);
            enemyHitEvent = FMODUnity.RuntimeManager.CreateInstance(EnemyHitEvent);
            noiseEvent = FMODUnity.RuntimeManager.CreateInstance(NoiseEvent);
            musicEvent = FMODUnity.RuntimeManager.CreateInstance(MusicEvent);

            sounds = new Dictionary<Sound, EventInstance>()
            {
                { Sound.Bullet , bulletEvent },
                { Sound.PlayerHit , playerHitEvent },
                { Sound.EnemyHit , enemyHitEvent },
                { Sound.Noise, noiseEvent },
                { Sound.Music, musicEvent }
            };
            loaded = true;
            sounds[Sound.Music].start();
        }

    }

    public void StartNoiseLeft()
    {
        sounds[Sound.Noise].setParameterByName("Panning", -60.0f);
        sounds[Sound.Noise].start();
    }

    public void StartNoiseCentered()
    {
        sounds[Sound.Noise].setParameterByName("Panning", 0.0f);
        sounds[Sound.Noise].start();
    }



    public void PlaySound(Sound sound, Transform t, Rigidbody2D rb = null)
    {
        sounds[sound].set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(t, rb));
        sounds[sound].start();
    }

    public void StopFadeOut(Sound sound, float fadeTime)
    {
        PLAYBACK_STATE isPlaying;
        sounds[sound].getPlaybackState(out isPlaying);

        if (isPlaying == PLAYBACK_STATE.PLAYING)
        {
            //sounds[sound].stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            IEnumerator fadeCoroutine = Fader(sounds[sound], fadeTime);
            StartCoroutine(fadeCoroutine);
        }
    }

    public IEnumerator Fader(EventInstance sound, float fadeTime)
    {
        float volume;
        sound.getVolume(out volume);
        

        while (volume > 0)
        {
            sound.setVolume(volume - 0.01f);
            volume -= 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        sound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
